using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework.Mapping
{
    class ScoreMap : EntityTypeConfiguration<Score>
    {
        /// <summary>
        /// Maps Score Class to the database
        /// </summary>
        public ScoreMap()
        {
            this.ToTable("Score");

            this.HasKey(b => b.Id)
                .Property(b => b.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
