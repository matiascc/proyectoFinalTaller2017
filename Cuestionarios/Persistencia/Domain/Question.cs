using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionSentence { get; set; }
        public int Difficulty { get; set; }
        public int Category { get; set; }
        public IList<Option> Options { get; set; }
        public int SetID { get; set; }
    }
}
