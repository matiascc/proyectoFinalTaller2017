using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            this.ToTable("Question");

            this.HasKey(b => b.id)
                .Property(b => b.id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(b => b.question)
                .IsRequired()
                .HasColumnName("question");

            this.Property(b => b.difficulty)
                .IsRequired()
                .HasColumnName("dificulty");

            this.Property(b => b.category)
                .IsRequired()
                .HasColumnName("category");

            this.HasMany<Option>(b => b.options)
                .WithRequired(b => b.question)
                .HasForeignKey<int>(b => b.questionID)
                .WillCascadeOnDelete();
        }
    }
}
