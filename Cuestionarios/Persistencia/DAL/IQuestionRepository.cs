using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DAL
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void AddOption(Option pOption);
    }
}
