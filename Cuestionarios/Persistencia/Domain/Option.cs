using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("Option")]
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public string Answer { get; set; }
        public Boolean Correct { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
