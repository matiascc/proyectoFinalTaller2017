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
    public class UserControler
    {
        UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;

        public UserControler(IMapper mapper) => _mapper = mapper;

        public void AddUser(string pUsername, string pPassword, Boolean pAdmin)
        {
            UserDTO usrDTO = new UserDTO();
            usrDTO.username = pUsername;
            usrDTO.password = pPassword;
            usrDTO.admin = pAdmin;

            User MapUser = _mapper.Map<UserDTO, User>(usrDTO);

            iUOfW.UserRepository.Add(MapUser);
            iUOfW.Complete();
        }

        /// <summary>
		/// Devuelve una campaña a partir de un ID ingresado
		/// </summary>
		/// <param name="pId"></param>
		/// <returns></returns>
		public UserDTO GetUser(string username)
        {
            User user = iUOfW.UserRepository.Get(username);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }
    }
}
