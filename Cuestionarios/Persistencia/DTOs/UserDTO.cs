using System;
using System.Collections.Generic;
using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean Admin { get; set; }
        public virtual IList<Score> Scores { get; set; }
    }
}
