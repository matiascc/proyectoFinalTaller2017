using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    public class DatabaseInitializationStrategy : CreateDatabaseIfNotExists<QuestionnaireDbContext>  
    {
        protected override void Seed(QuestionnaireDbContext context)
        {

            context.User.Add(new User
            {
                username = "admin",
                password = "admin",
                admin = true
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
