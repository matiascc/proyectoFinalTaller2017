using System.Collections.Generic;
using System.Linq;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;

namespace Questionnaire.Controlers
{
    public class SetController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());

        public SetController() { }
        
		public List<Set> GetAllSet()
        {
            return iUOfW.SetRepository.GetAll().ToList();
        }

    }
}
