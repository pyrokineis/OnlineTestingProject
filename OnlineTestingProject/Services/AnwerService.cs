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
        public AnswerResult CompareAnswer(UserAnswer userAnswer, Question qst)
        {
            throw new NotImplementedException();
        }

        public List<AnswersOption> GetAnswerOptions(Question qst)
        {
            throw new NotImplementedException();
        }
    }
}