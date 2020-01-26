using System;
using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;
using Questionnaire.DTOs;

namespace Questionnaire.Controlers
{
    public class UserController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        public void AddUser(string pUsername, string pPassword, Boolean pAdmin)
        {
            User usr = new User
            {
                Username = pUsername,
                Password = pPassword,
                Admin = pAdmin
            };
            if (iUOfW.UserRepository.GetByUserName(pUsername) == null)
            {
                iUOfW.UserRepository.Add(usr);
                iUOfW.Complete();
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Returns an user by his username
        /// </summary>
		public UserDTO GetUser(string username)
        {
            User user = iUOfW.UserRepository.GetByUserName(username);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }
    }
}
