﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DTOs
{
    public class UserDTO
    {
        public string username { get; set; }

        public string password { get; set; }

        public Boolean admin { get; set; }
    }
}
