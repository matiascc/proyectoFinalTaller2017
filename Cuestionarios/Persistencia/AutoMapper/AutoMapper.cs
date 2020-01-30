using AutoMapper;
using Questionnaire.Domain;
using Questionnaire.DTOs;

namespace Questionnaire.AutoMapper
{
    /// <summary>
    /// Maps the domain entities to DTOs and vice versa.
    /// </summary>
    public static class AutoMapper
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
