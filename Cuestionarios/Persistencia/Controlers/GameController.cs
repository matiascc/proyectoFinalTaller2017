using Questionnaire.DAL.EntityFramework;

namespace Questionnaire.Controlers
{
    public class GameController
    {
        readonly UnitOfWork iUOfW = new UnitOfWork(new QuestionnaireDbContext());
        
        public double CalculateScore(int correctAnswers, int totalQuestions, int difficulty, double time)
        {
            int difficultyFactor, timeFactor;
            
            switch (difficulty)
            {
                case 0:
                    difficultyFactor = 1;
                    break;
                case 1:
                    difficultyFactor = 3;
                    break;
                default:
                    difficultyFactor = 5;
                    break;
            }

            if (time < 5)
            {
                timeFactor = 5;
            }
            else if (time >= 5 && time <= 20)
            {
                timeFactor = 3;
            }
            else
            {
                timeFactor = 1;
            }

            return ((double)correctAnswers / (double)totalQuestions * (double)difficultyFactor * (double)timeFactor);
        }
    }
}
