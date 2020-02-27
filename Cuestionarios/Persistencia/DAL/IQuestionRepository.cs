using System;
using Questionnaire.Domain;
using Questionnaire.Source;
using Questionnaire.DAL.EntityFramework;
using System.Collections.Generic;

namespace Questionnaire.DAL
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void SaveQuestions(ISource pSource, string pDificulty, string pCategory, int pAmount, UnitOfWork pUnitOfWork);
        void AddOption(Option pOption);
        void DeleteAllQuestions();
        List<Question> GetQuestions(int pSet, int pDificulty, int pCategory, int pAmount);
        List<string> GetCategoriesOfSet(ISource pSource, int set);
        List<string> GetDifficultiesOfCategory(ISource pSource, int set, int category);
    }
}
