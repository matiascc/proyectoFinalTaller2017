using Questionnaire.Domain;

namespace Questionnaire.DTOs
{
    public class ScoreDTO
    {
        public int Id { get; set; }
        public virtual double ScoreValue { get; set; }
        public virtual string Username { get; set; }
        public virtual Score Score { get; set; }
    }
}
