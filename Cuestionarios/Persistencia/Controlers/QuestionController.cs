using Questionnaire.DAL.EntityFramework;
using Questionnaire.Source;
using Questionnaire.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Controlers
{
    public class QuestionController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());

        public QuestionController() { }

        public void SaveQuestions(ISource pSource, string pDificulty, string pCategory, int pAmount)
        {
            iUOfW.QuestionRepository.SaveQuestions(pSource, pDificulty, pCategory, pAmount, iUOfW);
        }
        
        public void DeleteQuestions()
        {
            iUOfW.QuestionRepository.DeleteAllQuestions();
        }

        public List<Question> GetQuestions(ISource pSource, int pDifficulty, int pCategory, int pAmount)
        {
            int set = iUOfW.SetRepository.GetSetByName(pSource.Name).Id;
            return iUOfW.QuestionRepository.GetQuestions(set, pDifficulty, pCategory, pAmount);
        }

        /// <summary>
        /// Get list of categories from questions in DB that correspond to a Set
        /// </summary>
        public List<string> GetCategoriesOfSet(ISource pSource)
        {
            int set = iUOfW.SetRepository.GetSetByName(pSource.Name).Id;

            return iUOfW.QuestionRepository.GetCategoriesOfSet(pSource, set);
        }

        /// <summary>
        /// Get list of difficulties from questions in DB that correspond to a Set and a category
        /// </summary>
        public List<string> GetDifficultiesOfCategory(ISource pSource, string pCategory)
        {
            int set = iUOfW.SetRepository.GetSetByName(pSource.Name).Id;

            int category = pSource.CategoryDictionary.FirstOrDefault(x => x.Value == pCategory).Key;

            return iUOfW.QuestionRepository.GetDifficultiesOfCategory(pSource, set, category);
        }

        /// <summary>
        /// Get amount of questions in DB that correspond to a Set, a category and a difficulty
        /// </summary>
        public int GetAmountOfQuestions(ISource pSource, string pCategory, string pDifficulty)
        {
            int set = iUOfW.SetRepository.GetSetByName(pSource.Name).Id;

            int category = pSource.CategoryDictionary.FirstOrDefault(x => x.Value == pCategory).Key;
            int difficulty = pSource.DifficultyDictionary.FirstOrDefault(x => x.Value == pDifficulty).Key;

            List<Question> listQuestions = iUOfW.QuestionRepository.GetAll().ToList().FindAll
                                                        (q => q.SetID == set && q.Category == category && q.Difficulty == difficulty);
            return listQuestions.Count;
        }
    }
}
