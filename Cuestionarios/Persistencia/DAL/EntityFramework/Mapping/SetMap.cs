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

            /*this.HasIndex(b => b.name)
                .IsUnique()
                .HasName("name");*/

            this.Property(b => b.name)
                .IsRequired()
                .HasColumnName("name");

            this.HasMany<Question>(b => b.questions)
                .WithRequired()
                .HasForeignKey<int>(b => b.setID)
                .WillCascadeOnDelete();

            /*this.HasMany<Question>(C => C.questions)
                .WithRequired(I => I.set)
                .Map(pMapping => pMapping.MapKey("setId"))
                .WillCascadeOnDelete();*/
        }
    }
}
