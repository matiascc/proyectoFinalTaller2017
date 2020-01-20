using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Domain
{
    public class Dificulty
    {
        public Dictionary<int, string> dificulty { get; set; }

        public void LoadCategories(Dictionary<int, string> pDictionary)
        {
            dificulty.Clear();
            dificulty = pDictionary;
        }
    }
}
