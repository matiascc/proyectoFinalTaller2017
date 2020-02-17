using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Source;
using Questionnaire.DTOs;
using Questionnaire.Domain;
using System.Collections.Generic;
using System;

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

        public List<QuestionDTO> GetQuestions(ISource pSource, int pDifficulty, int pCategory, int pAmount)
        {
            List<QuestionDTO> questionsDTOList = new List<QuestionDTO>();
            int set = iUOfW.SetRepository.GetSetByName(pSource.Name).Id;
            List<Question> questionsList = iUOfW.QuestionRepository.GetQuestions(set, pDifficulty, pCategory, pAmount);
            foreach (Question question in questionsList)
            {
                questionsDTOList.Add(_mapper.Map<Question, QuestionDTO>(question));
            }

            return questionsDTOList;
        }

        

    }
}
