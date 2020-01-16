using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class QuestionDTO
    {
        public int id { get; set; }
        public string question { get; set; }
        public virtual int dificulty { get; set; }
        public virtual int category { get; set; }
        public virtual IList<Option> options { get; set; }
    }
}
