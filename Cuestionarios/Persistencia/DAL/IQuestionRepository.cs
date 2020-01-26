using System;
using Questionnaire.Domain;
using Questionnaire.Source;
using Questionnaire.DAL.EntityFramework;

namespace Questionnaire.DAL
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void SaveQuestions(ISource pSource, string pDificulty, int pCategory, int pAmount, UnitOfWork pUnitOfWork);
        void AddOption(Option pOption);
        void DeleteAllQuestions();
        Boolean IsAlreadySaved(string pQuestion);
    }
}
