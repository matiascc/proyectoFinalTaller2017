using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap() 
        {
            // Nombre de la tabla que tendrá la entidad, en este caso 'Account'.
            this.ToTable("User");

            this.HasKey(b => b.username)
                .Property(b => b.username)
                .HasColumnName("username");

            this.Property(b => b.password)
                .IsRequired()
                .HasColumnName("password");

            this.Property(b => b.admin)
                .IsRequired()
                .HasColumnName("admin");
        }
    }
}
