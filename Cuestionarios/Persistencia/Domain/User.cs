using System;
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
    }
}
