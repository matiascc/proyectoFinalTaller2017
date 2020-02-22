using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Maps User Class to the database
        /// </summary>
        public UserMap() 
        {
            this.ToTable("User");

            this.HasKey(b => b.Username)
                .Property(b => b.Username)
                .HasColumnName("username");

            this.Property(b => b.Password)
                .IsRequired()
                .HasColumnName("password");

            this.Property(b => b.Admin)
                .IsRequired()
                .HasColumnName("admin");

            //Maps the relation between User and Score (One to Many)
            this.HasMany<Score>(b => b.Scores)
                .WithRequired(b => b.User)
                .HasForeignKey<string>(b => b.Username)
                .WillCascadeOnDelete();
        }
    }
}
