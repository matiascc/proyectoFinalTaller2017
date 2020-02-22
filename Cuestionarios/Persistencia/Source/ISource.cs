using System.Collections.Generic;
using Questionnaire.Domain;

namespace Questionnaire.Source
{
    public interface ISource
    {
        string Url { get; }
        string Name { get; }
        Dictionary<int, string> categoryDictionary { get; }
        Dictionary<int, string> difficultyDictionary { get; }
        List<Question> GetQuestions(string pDificulty, int pCategory, int pAmount);
        int GetDifficultyFactor(int difficulty);
        int GetTimeFactor(double time);
    }
}
