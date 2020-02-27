using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("User")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean Admin { get; set; }
        public virtual IList<Score> Scores { get; set; }
    }
}
