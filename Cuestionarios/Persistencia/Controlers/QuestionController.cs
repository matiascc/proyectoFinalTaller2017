using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Source;

namespace Questionnaire.Controlers
{
    public class QuestionController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;

        public QuestionController(IMapper mapper) => _mapper = mapper;

        public void SaveQuestions(ISource pSource, string pDificulty, int pCategory, int pAmount)
        {
            iUOfW.QuestionRepository.SaveQuestions(pSource, pDificulty, pCategory, pAmount, iUOfW);
        }
        
        public void DeleteQuestions()
        {
            iUOfW.QuestionRepository.DeleteAllQuestions();
        }

    }
}
