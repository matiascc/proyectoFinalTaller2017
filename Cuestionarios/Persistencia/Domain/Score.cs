using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Questionnaire.Domain
{
    [Table("Question")]
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public virtual double ScoreValue { get; set; }
        public virtual string Username { get; set; }
        public virtual User User { get; set; }
        public virtual double SecondsUsed { get; set; }
        public virtual DateTime DateOfScore { get; set; }
    }
}
