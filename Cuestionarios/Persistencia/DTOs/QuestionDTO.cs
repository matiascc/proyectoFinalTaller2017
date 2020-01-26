using System.Collections.Generic;
using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionSentence { get; set; }
        public virtual int Dificulty { get; set; }
        public virtual int Category { get; set; }
        public virtual IList<Option> Options { get; set; }
        public virtual int SetID { get; set; }
    }
}
