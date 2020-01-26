using Questionnaire.Domain;

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
            return this.iDbContext.Set<User>().Find(pUserName);
        }
    }
}
