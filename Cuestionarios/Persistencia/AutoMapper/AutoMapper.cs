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
            /*var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });

            var mapper = config.CreateMapper();*/

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });

            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}
