using System.Collections.Generic;

namespace Questionnaire.Domain
{
    public class Dificulty
    {
        public Dictionary<int, string> Dificulties { get; private set; }

        /// <summary>
        /// Change the dificulties
        /// </summary>
        /// <param name="pDictionary">A dictionary with the ids and dificulties</param>
        public void LoadCategories(Dictionary<int, string> pDictionary)
        {
            Dificulties.Clear();
            Dificulties = pDictionary;
        }
    }
}
