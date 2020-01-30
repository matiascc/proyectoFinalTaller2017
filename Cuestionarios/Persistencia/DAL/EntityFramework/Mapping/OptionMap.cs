using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class OptionMap : EntityTypeConfiguration<Option>
    {
        /// <summary>
        /// Maps Option Class to the database
        /// </summary>
        public OptionMap()
        {
            this.ToTable("Option");

            this.HasKey(b => b.Id)
                .Property(b => b.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(b => b.Answer)
                .IsRequired()
                .HasColumnName("answer");

            this.Property(b => b.Correct)
                .IsRequired()
                .HasColumnName("correct");
        }
    }
}
