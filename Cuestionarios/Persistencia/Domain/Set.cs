﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Questionnaire.Source;

namespace Questionnaire.Domain
{
    [Table("Set")]
    public class Set
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public virtual IList<Question> questions { get; set; }
    }
}
