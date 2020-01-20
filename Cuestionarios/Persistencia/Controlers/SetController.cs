using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;
using Questionnaire.DTOs;

namespace Questionnaire.Controlers
{
    public class SetController
    {
        UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;

        public SetController(IMapper mapper) => _mapper = mapper;
        
		public List<SetDTO> GetAllSet()
        {
            List<SetDTO> listSet = new List<SetDTO>();

            IEnumerable<Set> set = iUOfW.SetRepository.GetAll().ToList();
            iUOfW.Complete();
            foreach (var item in set)
            {
                listSet.Add(_mapper.Map<Set, SetDTO>(item));
            }
            return listSet;
        }

        public SetDTO GetSetByName(string pName)
        {
            return _mapper.Map<Set, SetDTO>(iUOfW.SetRepository.GetSetByName(pName)); ;
        }

    }
}
