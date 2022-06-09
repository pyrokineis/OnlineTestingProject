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
            return _dbContext.Questions.Get(id.ToString());
        }

        public Question GetQuestionByName(string text)
        {
            return _dbContext.Questions.Find(x=>x.Text==text).FirstOrDefault();
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

        public void DeleteQuestion(int id)
        {
            _dbContext.Questions.Delete(id);
            _dbContext.Save();
        }

        public QuestionType GetQuestionType(int id)
        {
            return _dbContext.QuestionTypes.Get(id.ToString());
        }

        public List<QuestionType> GetAllQuestionTypes()
        {
            return _dbContext.QuestionTypes.GetAll();
        }
        public List<string> GetAllQuestionTypesStrs()
        {
            return _dbContext.QuestionTypes.GetAll().Select(t => t.Name).ToList();
        }
        public QuestionType FindQuestionType(string name)
        {
            return _dbContext.QuestionTypes.Find(m=>m.Name==name.Trim()).FirstOrDefault();
        }

        public AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst)
        {
            throw new System.NotImplementedException();
        }
    }
}