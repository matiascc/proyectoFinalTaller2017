﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Domain
{
    public class Category
    {
        public Dictionary<int, string> category { get; set; }


        public void LoadCategories(Dictionary<int, string> pDictionary)
        {
            category.Clear();
            category = pDictionary;
        }
    }
}
