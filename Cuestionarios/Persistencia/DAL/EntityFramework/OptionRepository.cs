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
        
    }
}
