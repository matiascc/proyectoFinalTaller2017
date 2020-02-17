using System.Linq;
using Questionnaire.Domain;
using Npgsql;
using System;

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
            try
            {
                return iDbContext.Sets.Where(s => s.Name == pName).Single();
            }
            catch (Exception ex)
            {
                throw new NpgsqlException("Error trying to get set name: ", ex);
            }
        }

        /// <summary>
        /// Adds a question to the database
        /// </summary>
        public void AddQuestion(Question pQuestion) 
        {
            try
            {
                iDbContext.Question.Attach(pQuestion);
                iDbContext.Question.Add(pQuestion);
                iDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NpgsqlException("Error trying to add questions: ", ex);
            }
        }
    }
}