using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Domain
{
    [Table("Set")]
    public class Set
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Question> Questions { get; set; }
    }
}
