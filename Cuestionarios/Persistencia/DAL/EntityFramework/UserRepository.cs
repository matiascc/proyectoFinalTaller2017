using Questionnaire.Domain;
using System;
using Npgsql;
using System.Linq;
using System.Collections.Generic;

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
        public void AddScore(User user, double scoreValue, double time)
        {
            Score score = new Score
            {
                ScoreValue = Math.Truncate(100 * scoreValue) / 100,
                User = user,
                Username = user.Username,
                SecondsUsed = time,
                DateOfScore = DateTime.Now
            };

            try
            {
                iDbContext.Score.Attach(score);
                iDbContext.Score.Add(score);
                iDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NpgsqlException("Error trying to add new score: ", ex);
            }
            
        }

        /// <summary>
        /// Gets top 20 High Scores
        /// </summary>
        public List<Score> GetHighScores()
        {
            try
            {
                var query = from s in iDbContext.Score
                            orderby s.ScoreValue descending
                            select s;

                if (query.ToList().Count > 20)
                    return (query.Take(20).ToList());
                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
        }

    }
}
