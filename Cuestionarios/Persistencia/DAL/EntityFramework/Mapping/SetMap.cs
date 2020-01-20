using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class SetMap : EntityTypeConfiguration<Set>
    {
        public SetMap()
        {
            this.ToTable("Set");

            this.HasKey(b => b.id)
                .Property(b => b.id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(b => b.name)
                .IsRequired()
                .HasColumnName("name");

            this.HasMany<Question>(b => b.questions)
                .WithRequired()
                .HasForeignKey<int>(b => b.setID)
                .WillCascadeOnDelete();
        }
    }
}
