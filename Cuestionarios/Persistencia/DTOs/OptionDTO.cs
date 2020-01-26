using System;
using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public Boolean Correct { get; set; }
        public virtual int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
