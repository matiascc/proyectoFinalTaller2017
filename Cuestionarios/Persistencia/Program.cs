using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.DAL.EntityFramework;
using System.Data.Entity;

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


