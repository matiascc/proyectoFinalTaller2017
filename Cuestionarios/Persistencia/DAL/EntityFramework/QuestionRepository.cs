using System;
using System.Collections.Generic;
using System.Linq;
using Questionnaire.Domain;
using Questionnaire.Source;

namespace Questionnaire.DAL.EntityFramework
{
    class QuestionRepository : Repository<Question, QuestionnaireDbContext>, IQuestionRepository
    {
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

                    //Add the question to the DB
                    question.SetID = selectedSet.Id;
                    iDbContext.Question.Add(question);
                    pUnitOfWork.SetRepository.AddQuestion(question);

                    //Add each option to the DB
                    foreach (Option option in optionsList)
                    {
                        option.Question = question;
                        option.QuestionID = question.Id;
                        this.AddOption(option);
                    }
                }
            }
        }

        /// <summary>
        /// Adds an option related to that question
        /// </summary>
        public void AddOption(Option pOption)
        {
            iDbContext.Options.Attach(pOption);
            iDbContext.Options.Add(pOption);
            iDbContext.SaveChanges();
        }

        /// <summary>
        /// Returns if the question is already in the database
        /// </summary>
        public Boolean IsAlreadySaved(string pQuestion)
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
            foreach (Question question in this.GetAll())
            {
                iDbContext.Question.Remove(question);
            }
            iDbContext.SaveChanges();
        }
    }
}
