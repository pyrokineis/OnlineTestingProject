using System.Collections;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;

namespace OnlineTestingProject.Interfaces
{
    public interface IAnswerService
    {
        AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst);
    }
}