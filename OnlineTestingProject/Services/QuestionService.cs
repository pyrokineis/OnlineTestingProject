using System.Collections.Generic;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;

namespace OnlineTestingProject.Services
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _dbContext { get; set; }

        public QuestionService(IUnitOfWork uoW)
        {
            _dbContext = uoW;
        }
        public Question GetQuestion(int id)
        {
            return _dbContext.Questions.Get(id);
        }
        public List<Question> GetQuestions()
        {
            return _dbContext.Questions.GetAll();
        }
        public void AddQuestion(Question qst)
        {
            _dbContext.Questions.Add(qst);
            _dbContext.Questions.Save();
        }

        public QuestionType GetQuestionType(int id)
        {
            return _dbContext.QuestionTypes.Get(id);
        }

        public List<QuestionType> GetAllQuestionTypes()
        {
            return _dbContext.QuestionTypes.GetAll();
        }

        public AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst)
        {
            throw new System.NotImplementedException();
        }
    }
}