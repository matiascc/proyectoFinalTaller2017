using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    class UserRepository : Repository<User, QuestionnaireDbContext>, IUserRepository
    {
        public UserRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
           
        }
        public User Get(string pId)
        {
            return this.iDbContext.Set<User>().Find(pId);
        }
    }
}
