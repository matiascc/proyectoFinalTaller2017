using Questionnaire.Domain;

namespace Questionnaire.DAL
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string pUserName);
        void AddScore(User user, double score);
    }
}
