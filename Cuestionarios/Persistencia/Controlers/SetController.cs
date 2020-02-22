using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;
using Questionnaire.DTOs;

namespace Questionnaire.Controlers
{
    public class SetController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;

        public SetController(IMapper mapper) => _mapper = mapper;
        
		public List<SetDTO> GetAllSet()
        {
            List<SetDTO> listSet = new List<SetDTO>();

            IEnumerable<Set> set = iUOfW.SetRepository.GetAll().ToList();
            foreach (var item in set)
            {
                listSet.Add(_mapper.Map<Set, SetDTO>(item));
            }
            return listSet;
        }

    }
}
