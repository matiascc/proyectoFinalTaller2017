using Questionnaire.DAL.EntityFramework;
using System;

namespace Questionnaire
{
    class Program
    {
        static void Main()
        {
            QuestionnaireDbContext db = new QuestionnaireDbContext();
            Console.ReadKey();
        }
    }
}


