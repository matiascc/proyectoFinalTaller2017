using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("Option")]
    public class Option
    {
        [Key]
        public int id { get; set; }
        public string answer { get; set; }
        public Boolean correct { get; set; }
    }
}
