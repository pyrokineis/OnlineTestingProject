using System.Collections.Generic;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;

namespace OnlineTestingProject.Interfaces
{
    public interface IQuestionService
    {
        void AddQuestion(Question qst);
        List<Question> GetQuestions();
        Question GetQuestion(int id);
        List<QuestionType> GetAllQuestionTypes();
        List<string> GetAllQuestionTypesStrs();
        QuestionType GetQuestionType(int id);
        AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst);
        QuestionType FindQuestionType(string name);
    }
}