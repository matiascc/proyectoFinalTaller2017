using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Questionnaire.Domain;
using Questionnaire.DTOs;

namespace Questionnaire.AutoMapper
{
    public class AutoMapper
    {
        public static IMapper ConfigureAutomapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Set, SetDTO>().ReverseMap();
                cfg.CreateMap<Question, QuestionDTO>().ReverseMap();
                cfg.CreateMap<Option, OptionDTO>().ReverseMap();
            });

            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}
