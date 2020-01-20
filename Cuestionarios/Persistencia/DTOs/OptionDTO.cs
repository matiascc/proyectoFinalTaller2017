using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class OptionDTO
    {
        public int id { get; set; }
        public string answer { get; set; }
        public Boolean correct { get; set; }
        public virtual int questionID { get; set; }
        public virtual Question question { get; set; }
    }
}
