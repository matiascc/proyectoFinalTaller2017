using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int id { get; set; }
        public string question { get; set; }
        public virtual int difficulty { get; set; }
        public virtual int category { get; set; }
        public virtual IList<Option> options { get; set; }
        public virtual int setID { get; set; }
    }
}
