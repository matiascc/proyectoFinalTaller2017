using System;
using Questionnaire.DAL.EntityFramework;
using Questionnaire.Domain;
using System.Collections.Generic;

namespace Questionnaire.Controlers
{
    public class UserController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());

        public UserController() { }

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
		public User GetUser(string username)
        {
            return iUOfW.UserRepository.GetByUserName(username);
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
        public List<Score> GetHighScores()
        {
            return iUOfW.UserRepository.GetHighScores();
        }
    }
}
