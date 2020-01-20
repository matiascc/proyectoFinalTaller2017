using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    class QuestionRepository : Repository<Question, QuestionnaireDbContext>, IQuestionRepository
    {
        public QuestionRepository(QuestionnaireDbContext pContext) : base(pContext)
        {

        }
        public void AddOption(Option pOption)
        {
            iDbContext.Options.Attach(pOption);
            iDbContext.Options.Add(pOption);

            iDbContext.SaveChanges();
        }
    }
}
