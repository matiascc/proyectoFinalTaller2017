using System;
using System.Data.Entity;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    public class DatabaseInitializationStrategy : DropCreateDatabaseIfModelChanges<QuestionnaireDbContext>  
    {
        protected override void Seed(QuestionnaireDbContext context)
        {
            //Adds the default admin user
            context.User.Add(new User
            {
                Username = "admin",
                Password = "admin",
                Admin = true
            });

            //Adds the default set of questions
            context.Sets.Add(new Set
            {
                Name = "opentdb"
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
