using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class SetMap : EntityTypeConfiguration<Set>
    {
        /// <summary>
        /// Maps Set Class to the database
        /// </summary>
        public SetMap()
        {
            this.ToTable("Set");

            this.HasKey(b => b.Id)
                .Property(b => b.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(b => b.Name)
                .IsRequired()
                .HasColumnName("name");

            //Maps the relation between Set and Question (One to Many)
            this.HasMany<Question>(b => b.Questions)
                .WithRequired()
                .HasForeignKey<int>(b => b.SetID)
                .WillCascadeOnDelete();
        }
    }
}
