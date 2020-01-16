using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;
using Questionnaire.Source;

namespace Questionnaire.DTOs
{
    public class SetDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual IList<Question> questions { get; set; }
    }
}
