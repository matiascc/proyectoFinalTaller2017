using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("User")]
    public class User
    {
        [Key]
        public string username { get; set; }

        public string password { get; set; }

        public Boolean admin { get; set; }
    }
}
