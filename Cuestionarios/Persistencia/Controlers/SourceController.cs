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
        public List<ISource> sourcesList { get; set; }

        public SourceController()
        {
            sourcesList = new List<ISource>();
            this.sourcesList.Add(new OpentdbSource());
        }

        public ISource GetSourceByName(string pName)
        {
            return (sourcesList.Find(s => s.Name == pName));
        }
    }
}
