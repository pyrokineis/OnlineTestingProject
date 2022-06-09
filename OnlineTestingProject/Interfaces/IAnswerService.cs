using System.Collections;
using System.Collections.Generic;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;

namespace OnlineTestingProject.Interfaces
{
    public interface IAnswerService
    {
        AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst);
        List<AnswersOption> GetAnswerOptions(Question qst);
        List<AnswersOption> GetAnswersOptions(List<Question> qstList);
        void AddAnswerOption(Question qst, string text);

    }
}