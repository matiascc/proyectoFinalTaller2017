using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class QuestionMap : EntityTypeConfiguration<Question>
    {
        /// <summary>
        /// Maps Question Class to the database
        /// </summary>
        public QuestionMap()
        {
            this.ToTable("Question");

            this.HasKey(b => b.Id)
                .Property(b => b.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(b => b.QuestionSentence)
                .IsRequired()
                .HasColumnName("question");

            this.Property(b => b.Difficulty)
                .IsRequired()
                .HasColumnName("dificulty");

            this.Property(b => b.Category)
                .IsRequired()
                .HasColumnName("category");

            //Maps the relation between Question and Option (One to Many)
            this.HasMany<Option>(b => b.Options)
                .WithRequired(b => b.Question)
                .HasForeignKey<int>(b => b.QuestionID)
                .WillCascadeOnDelete();
        }
    }
}
