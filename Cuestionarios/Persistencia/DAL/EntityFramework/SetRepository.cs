using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    class SetRepository : Repository<Set, QuestionnaireDbContext>, ISetRepository
    {
        public SetRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
            
        }

        public Set GetSetByName(string pName)
        {
            return iDbContext.Sets.Where(s => s.name == pName).Single();
        }

        public void AddQuestion(Question pQuestion) 
        {
            iDbContext.Question.Attach(pQuestion);
            iDbContext.Question.Add(pQuestion);
            iDbContext.SaveChanges();
        }
    }
}