using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;
using Questionnaire.DTOs;
using Questionnaire.Source;

namespace Questionnaire.Controlers
{
    public class QuestionController
    {
        UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;
        private readonly ISource _source;
        private readonly SetController _setController;

        public QuestionController(IMapper mapper, SetController setController) 
        {
            _mapper = mapper;
            _setController = setController;
        } 

        public void SaveQuestions(ISource pSource, string pDificulty, int pCategory, int pAmount)
        {
            
            List<Question> questionsList = pSource.GetQuestions(pDificulty, pCategory, pAmount);
            foreach (Question question in questionsList)
            {
                //question.setQuestion = (_mapper.Map<SetDTO, Set>(_setController.GetSetByName(pSource.Name)));
                iUOfW.QuestionRepository.Add(question);
                iUOfW.Complete();
            }
        }
    }
}
