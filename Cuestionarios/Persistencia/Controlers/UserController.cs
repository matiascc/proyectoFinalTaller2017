using System;
using AutoMapper;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;
using Questionnaire.DTOs;
using System.Collections.Generic;

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
                Admin = pAdmin,
                Scores = new List<Score>()
            };
            if (iUOfW.UserRepository.GetByUserName(pUsername) == null)
            {
                iUOfW.UserRepository.Add(usr);
                iUOfW.Complete();
            }
            else
            {
                throw new Exception("There is already a user with that username");
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

        /// <summary>
        /// Save the score to a username
        /// </summary>
        public void SaveScore(string username, double scoreValue, double time)
        {
            User user = iUOfW.UserRepository.GetByUserName(username);
            iUOfW.UserRepository.AddScore(user, scoreValue, time);
        }

        /// <summary>
        /// Gets the top 20 High Scores
        /// </summary>
        public List<ScoreDTO> GetHighScores()
        {
            List<ScoreDTO> scores = new List<ScoreDTO>();

            foreach (Score scr in iUOfW.UserRepository.GetHighScores())
            {
                scores.Add(_mapper.Map<Score, ScoreDTO>(scr));
            }
            return scores;
        }
    }
}
