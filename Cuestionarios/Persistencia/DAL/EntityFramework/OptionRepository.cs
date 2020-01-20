using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    class OptionRepository : Repository<Option, QuestionnaireDbContext>, IOptionRepository
    {
        public OptionRepository(QuestionnaireDbContext pContext) : base(pContext)
        {

        }

        public int GetLastIndex()
        {
            List<Option> listOptions = (from i in iDbContext.Options select i).ToList();
            return listOptions.Count;
        }

        
    }
}
