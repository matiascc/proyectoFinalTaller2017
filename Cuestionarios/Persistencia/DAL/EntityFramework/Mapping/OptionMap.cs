using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class OptionMap : EntityTypeConfiguration<Option>
    {
        public OptionMap()
        {
            this.ToTable("Option");

            this.HasKey(b => b.id)
                .Property(b => b.id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(b => b.answer)
                .IsRequired()
                .HasColumnName("answer");

            this.Property(b => b.correct)
                .IsRequired()
                .HasColumnName("correct");
        }
    }
}
