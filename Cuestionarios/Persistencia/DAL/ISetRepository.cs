using Questionnaire.Domain;

namespace Questionnaire.DAL
{
    public interface ISetRepository : IRepository<Set>
    {
        Set GetSetByName(string pName);
        void AddQuestion(Question pQuestion);
    }
}
