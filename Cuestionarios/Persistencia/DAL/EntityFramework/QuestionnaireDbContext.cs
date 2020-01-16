using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;
using Questionnaire.Source;
using Questionnaire.DAL.EntityFramework.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Questionnaire.DAL.EntityFramework
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext() : base(nameOrConnectionString: "Default")
        {
            // Se establece la estrategia personalizada de inicialización de la BBDD.
            Database.SetInitializer<QuestionnaireDbContext>(new DatabaseInitializationStrategy());
            Database.Initialize(false);
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Option> Option { get; set; }

        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            pModelBuilder.Configurations.Add(new UserMap());

            base.OnModelCreating(pModelBuilder);
        }
    }
}
