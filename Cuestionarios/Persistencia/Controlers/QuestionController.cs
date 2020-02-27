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

        public List<Question> GetAllQuestionsOfSet(ISource pSource)
        {
            int set = iUOfW.SetRepository.GetSetByName(pSource.Name).Id;
            List<Question> listQuestions = iUOfW.QuestionRepository.GetAll().ToList();
            return listQuestions.FindAll(q => q.SetID == set);
        }
    }
}
