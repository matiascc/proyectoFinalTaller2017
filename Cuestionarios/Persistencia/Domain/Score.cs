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
        public double ScoreValue { get; set; }
        public string Username { get; set; }
        public User User { get; set; }
        public double SecondsUsed { get; set; }
        public DateTime DateOfScore { get; set; }
    }
}
