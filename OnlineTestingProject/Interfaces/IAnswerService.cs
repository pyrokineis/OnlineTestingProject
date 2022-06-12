using System.Collections;
using System.Collections.Generic;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;

namespace OnlineTestingProject.Interfaces
{
    public interface IAnswerService
    {
        AnswerResult CompareAnswer(Question qst, Test test, string userId, string AnsData);
        List<AnswersOption> GetAnswerOptions(Question qst);
        List<AnswersOption> GetAnswersOptions(List<Question> qstList);
        void AddAnswerOption(Question qst, string text);
        string[] GetAnswerOptionsStrings(Question qst);
        void AddUserAnswer(Question qst, Test test, string ansData, string userId, AnswerResult res);
        List<UserAnswer> GetUserAnswersInTest(Test test, string userId);
    }
}