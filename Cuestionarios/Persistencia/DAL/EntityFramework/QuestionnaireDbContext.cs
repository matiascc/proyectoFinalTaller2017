using System;
using Questionnaire.Domain;
using Questionnaire.DAL.EntityFramework.Mapping;
using System.Data.Entity;

namespace Questionnaire.DAL.EntityFramework
{
    public class QuestionnaireDbContext : DbContext
    {
        /// <summary>
        /// Initialize the DB
        /// </summary>
        public QuestionnaireDbContext() : base(nameOrConnectionString: "Default")
        {
            // The customized initialization strategy of the DB is established.  
            Database.SetInitializer<QuestionnaireDbContext>(new DatabaseInitializationStrategy());
            Database.Initialize(false);
        }

        //All the clases of the DB
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Score> Score { get; set; }

        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            if (pModelBuilder == null)
            {
                throw new ArgumentNullException(nameof(pModelBuilder));
            }

            //Adds each entity map
            pModelBuilder.Configurations.Add(new UserMap());
            pModelBuilder.Configurations.Add(new OptionMap());
            pModelBuilder.Configurations.Add(new SetMap());
            pModelBuilder.Configurations.Add(new QuestionMap());
            pModelBuilder.Configurations.Add(new ScoreMap());

            base.OnModelCreating(pModelBuilder);
        }
    }
}
