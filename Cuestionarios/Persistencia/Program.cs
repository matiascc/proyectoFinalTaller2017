using Questionnaire.DAL.EntityFramework;
using Questionnaire.Source;
using System;
using System.Collections.Generic;

namespace Questionnaire
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionnaireDbContext db = new QuestionnaireDbContext();
            Console.WriteLine("EXITO");
            Console.ReadKey();
        }
    }
}


