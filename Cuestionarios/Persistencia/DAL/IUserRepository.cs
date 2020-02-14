using Questionnaire.Domain;
using System.Collections.Generic;

namespace Questionnaire.DAL
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string pUserName);
        void AddScore(User user, double score, double time);
        List<Score> GetHighScores();
    }
}
