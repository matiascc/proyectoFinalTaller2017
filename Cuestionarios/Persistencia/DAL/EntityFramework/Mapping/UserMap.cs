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
            // Nombre de la tabla que tendrá la entidad, en este caso 'Account'.
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
        }
    }
}
