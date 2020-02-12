using Questionnaire.Domain;
using System;
using Npgsql;

namespace Questionnaire.DAL.EntityFramework
{
    class UserRepository : Repository<User, QuestionnaireDbContext>, IUserRepository
    {
        public UserRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
        }
        
        /// <summary>
        /// Gets User by username
        /// </summary>
        public User GetByUserName(string pUserName)
        {
            try
            {
                return this.iDbContext.Set<User>().Find(pUserName);
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());   
            }
        }

        /// <summary>
        /// Add the score to a user
        /// </summary>
        public void AddScore(User user, double scoreValue)
        {
            Score score = new Score
            {
                ScoreValue = scoreValue,
                User = user,
                Username = user.Username
            };

            iDbContext.Score.Attach(score);
            iDbContext.Score.Add(score);
            iDbContext.SaveChanges();
        }

    }
}
