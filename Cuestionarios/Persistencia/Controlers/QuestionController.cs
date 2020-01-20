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
            SetDTO selectedSet = _setController.GetSetByName(pSource.Name);
            Set set = _mapper.Map<SetDTO, Set>(selectedSet);

            List<Question> questionsList = pSource.GetQuestions(pDificulty, pCategory, pAmount);
            foreach (Question question in questionsList)
            {
                if (!IsAlreadySaved(question.question))
                {
                    IList<Option> optionsList = new List<Option>();
                    foreach (Option opt in question.options)
                    {
                        optionsList.Add(opt);
                    }
                    question.options.Clear();

                    question.setID = set.id;
                    iUOfW.SetRepository.AddQuestion(question);

                    foreach (Option option in optionsList)
                    {
                        option.question = question;
                        option.questionID = question.id;
                        iUOfW.QuestionRepository.AddOption(option);
                    }
                }
            }
            iUOfW.Complete();
        }

        private Boolean IsAlreadySaved(string pQuestion)
        {
            IEnumerable<Question> questionsList = new List<Question>(); 
            questionsList = iUOfW.QuestionRepository.GetAll();
            Question result = questionsList.ToList().Find(s => s.question == pQuestion);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteQuestions()
        {
            foreach (Question question in iUOfW.QuestionRepository.GetAll())
            {
                iUOfW.QuestionRepository.Remove(question);
            }
            iUOfW.Complete();
        }

        public int GetAmount ()
        {
            return iUOfW.QuestionRepository.GetAll().Count();
        }

    }
}
