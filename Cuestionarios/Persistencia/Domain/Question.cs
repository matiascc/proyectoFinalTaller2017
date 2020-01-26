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
        public virtual int Difficulty { get; set; }
        public virtual int Category { get; set; }
        public virtual IList<Option> Options { get; set; }
        public virtual int SetID { get; set; }
    }
}
