using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Questionnaire.Domain;
using Questionnaire.Source;

namespace Questionnaire.DAL.EntityFramework
{
    public class DatabaseInitializationStrategy : DropCreateDatabaseAlways<QuestionnaireDbContext>  
    {
        protected override void Seed(QuestionnaireDbContext context)
        {

            context.User.Add(new User
            {
                username = "admin",
                password = "admin",
                admin = true
            });

            context.Sets.Add(new Set
            {
                name = "opentdb"
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
