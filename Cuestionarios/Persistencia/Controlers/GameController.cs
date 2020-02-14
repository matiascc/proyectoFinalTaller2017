using Questionnaire.DAL.EntityFramework;
using Questionnaire.Source;

namespace Questionnaire.Controlers
{
    public class GameController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        
        public double CalculateScore(ISource source, int correctAnswers, int totalQuestions, int difficulty, double time)
        {
            int difficultyFactor, timeFactor;

            difficultyFactor = source.GetDifficultyFactor(difficulty);
            timeFactor = source.GetTimeFactor(time);

            return (    (  (double)correctAnswers / (double)totalQuestions  ) * (double)difficultyFactor * (double)timeFactor    );
        }
    }
}
