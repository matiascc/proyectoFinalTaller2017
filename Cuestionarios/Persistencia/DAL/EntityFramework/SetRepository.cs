using System.Linq;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    class SetRepository : Repository<Set, QuestionnaireDbContext>, ISetRepository
    {
        public SetRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
        }

        /// <summary>
        /// Returns a set by the name parameter
        /// </summary>
        public Set GetSetByName(string pName)
        {
            return iDbContext.Sets.Where(s => s.Name == pName).Single();
        }

        /// <summary>
        /// Adds a question to the database
        /// </summary>
        public void AddQuestion(Question pQuestion) 
        {
            iDbContext.Question.Attach(pQuestion);
            iDbContext.Question.Add(pQuestion);
            iDbContext.SaveChanges();
        }
    }
}