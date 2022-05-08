using System.Collections.Generic;
using System.Linq;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Services
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork _dbContext { get; set; }

        public QuestionService(IUnitOfWork uoW)
        {
            _dbContext = uoW;
        }
        public Question GetQuestion(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddQuestion(Question qst)
        {
            throw new System.NotImplementedException();
        }

        public List<Question> GetQuestions()
        {
            return _dbContext.Questions.GetAll();
        }
    }
}