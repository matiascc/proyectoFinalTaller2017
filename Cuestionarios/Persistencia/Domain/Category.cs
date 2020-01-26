using System.Collections.Generic;

namespace Questionnaire.Domain
{
    public class Category
    {
        public Dictionary<int, string> Categories { get; private set; }

        /// <summary>
        /// Change the categories
        /// </summary>
        /// <param name="pDictionary">A dictionary with the ids and categories</param>
        public void LoadCategories(Dictionary<int, string> pDictionary)
        {
            Categories.Clear();
            Categories = pDictionary;
        }
    }
}
