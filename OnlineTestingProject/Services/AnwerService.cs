using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Services
{
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork _dbContext { get; set; }

        public AnswerService(IUnitOfWork uoW)
        {
            _dbContext = uoW;
        }

        public AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst)
        {
            throw new NotImplementedException();
        }

        public List<AnswersOption> GetAnswerOptions(Question qst)
        {
            var list = _dbContext.AnswersOptions.GetAll();
           return _dbContext.AnswersOptions.GetAll().Where(x => x.QuestionId == qst.Id).ToList();
        }

        public List<AnswersOption> GetAnswersOptions(List<Question> qstList)
        {
            List<AnswersOption> list = new List<AnswersOption>();

            foreach (Question qst in qstList)
            {
                list.AddRange(GetAnswerOptions(qst));
            }
            return list;
        }

        public void AddAnswerOption(Question qst, string text)
        {
            _dbContext.Questions.Attach(qst);
            _dbContext.AnswersOptions.Add(new AnswersOption { 
                QuestionId = qst.Id,
                Text = text,
            });
            _dbContext.Save();
        }
    }
}