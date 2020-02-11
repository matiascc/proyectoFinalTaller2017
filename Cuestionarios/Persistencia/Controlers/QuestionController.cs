using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Source;
using Questionnaire.DTOs;
using Questionnaire.Domain;
using System.Collections.Generic;

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

        public List<QuestionDTO> GetQuestions(ISource pSource, string pDificulty, int pCategory, int pAmount)
        {
            List<QuestionDTO> questionsDTOList = new List<QuestionDTO>();
            List<Question> questionsList = pSource.GetQuestions(pDificulty, pCategory, pAmount);
            foreach (Question question in questionsList)
            {
                questionsDTOList.Add(_mapper.Map<Question, QuestionDTO>(question));
            }

            return questionsDTOList;
        }

    }
}
