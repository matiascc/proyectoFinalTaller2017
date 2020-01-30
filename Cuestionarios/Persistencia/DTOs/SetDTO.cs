using System.Collections.Generic;
using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class SetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Question> Questions { get; set; }
    }
}
