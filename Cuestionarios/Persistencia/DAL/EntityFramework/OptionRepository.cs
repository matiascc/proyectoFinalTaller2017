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
