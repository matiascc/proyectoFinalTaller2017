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
    public class SourceController
    {
        UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;
        public List<ISource> sourcesList { get; set; }

        public SourceController(IMapper mapper)
        {
            _mapper = mapper;
            sourcesList = new List<ISource>();
            this.sourcesList.Add(new OpentdbSource());
        }

        public ISource GetSourceByName(string pName)
        {
            return (sourcesList.Find(s => s.Name == pName));
        }
    }
}
