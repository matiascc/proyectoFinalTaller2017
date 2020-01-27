using Questionnaire.Domain;
using System;
using Npgsql;

namespace Questionnaire.DAL.EntityFramework
{
    class UserRepository : Repository<User, QuestionnaireDbContext>, IUserRepository
    {
        public UserRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
        }
        
        /// <summary>
        /// Gets User by username
        /// </summary>
        public User GetByUserName(string pUserName)
        {
            try
            {
                return this.iDbContext.Set<User>().Find(pUserName);
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());   
            }
        }
    }
}
