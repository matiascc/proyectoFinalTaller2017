using System;
using System.Collections.Generic;
using System.Linq;
using Questionnaire.Domain;
using Questionnaire.Source;
using Npgsql;

namespace Questionnaire.DAL.EntityFramework
{
    class QuestionRepository : Repository<Question, QuestionnaireDbContext>, IQuestionRepository
    {
        private static readonly Random rng = new Random();

        public QuestionRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
        }

        /// <summary>
        /// Saves a question and its respective options in the DB
        /// </summary>
        /// <param name="pSource">Source class from where to get the questions</param>
        public void SaveQuestions(ISource pSource, string pDificulty, int pCategory, int pAmount, UnitOfWork pUnitOfWork)
        {
            Set selectedSet = pUnitOfWork.SetRepository.GetSetByName(pSource.Name);

            List<Question> questionsList = pSource.GetQuestions(pDificulty, pCategory, pAmount);

            try
            {
                foreach (Question question in questionsList)
                {
                    if (!this.IsAlreadySaved(question.QuestionSentence))
                    {
                        //Put the options in a separete list and delete them from the question
                        IList<Option> optionsList = new List<Option>();
                        foreach (Option opt in question.Options)
                        {
                            optionsList.Add(opt);
                        }
                        question.Options.Clear();

                        question.QuestionSentence = CleanString(question.QuestionSentence);

                        //Add the question to the DB
                        question.SetID = selectedSet.Id;
                        iDbContext.Question.Add(question);
                        pUnitOfWork.SetRepository.AddQuestion(question);

                        //Add each option to the DB
                        foreach (Option option in optionsList)
                        {
                            option.Answer = CleanString(option.Answer);
                            option.Question = question;
                            option.QuestionID = question.Id;
                            this.AddOption(option);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
        }

        /// <summary>
        /// Replace special characters with correct format
        /// </summary>
        private string CleanString(string pSentence)
        {
            pSentence = pSentence.Replace("&amp;", "&");
            pSentence = pSentence.Replace("&quot;", "\"");
            pSentence = pSentence.Replace("&#039;", "'");
            return pSentence;
        }

        /// <summary>
        /// Adds an option related to that question
        /// </summary>
        public void AddOption(Option pOption)
        {
            try
            {
                iDbContext.Options.Attach(pOption);
                iDbContext.Options.Add(pOption);
                iDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NpgsqlException("Error trying to add new options: ", ex);
            }
        }

        /// <summary>
        /// Returns if the question is already in the database
        /// </summary>
        private Boolean IsAlreadySaved(string pQuestion)
        {
            IEnumerable<Question> questionsList = new List<Question>();
            questionsList = this.GetAll();
            Question result = questionsList.ToList().Find(s => s.QuestionSentence == pQuestion);

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Delete all questions from the database
        /// </summary>
        public void DeleteAllQuestions()
        {
            try
            {
                foreach (Question question in this.GetAll())
                {
                    iDbContext.Question.Remove(question);
                }
                iDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
        }

        public List<Question> GetQuestions(int pSet, int pDifficulty, int pCategory, int pAmount)
        {
            List<Question> questionsList = new List<Question>();
            try
            {
                var query = from q in iDbContext.Question
                            where q.SetID == pSet &&
                            q.Difficulty == pDifficulty &&
                            q.Category == pCategory
                            select q;
                
                questionsList = query.ToList();

                if (questionsList.Count < pAmount)
                {
                    throw new InvalidOperationException();
                }

                Shuffle(questionsList);
                questionsList.Take(pAmount);
            }
            catch(Exception ex)
            {
                throw new NpgsqlException("Error trying to get questions: ", ex);
            }

            foreach (Question question in questionsList)
            {
                Shuffle(question.Options);;
            }

            return questionsList;
        }

        /// <summary>
        /// Shuffle array
        /// </summary>
        private void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
