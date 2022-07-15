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

        public AnswerResult CompareAnswer(Question qst, Test test, string userId, string AnsData)
        {
            switch (qst.Type)
            {

                case QuestionsTypes.Тестовый:  //single
                    if (AnsData == qst.AnswerData)
                        return AnswerResult.Max;
                    return AnswerResult.Min;

                case QuestionsTypes.НесколькоВариатов:  //multiple
                    string[] mas1 = AnsData.Split(',');  //user
                    string[] mas2 = qst.AnswerData.Split(',');  //true
                    bool isSubset = mas1.All(elem => mas2.Contains(elem));
                    if (isSubset)
                        return AnswerResult.Max;

                    int k = 0;
                    foreach (var element in mas1)
                    {
                        if (mas2.Contains(element))
                        {
                            k++;
                            break;
                        }
                    }
                    if (k > 0)
                        return AnswerResult.Half;

                    return AnswerResult.Min;

                case QuestionsTypes.Текстовый: //text
                    if (AnsData==qst.AnswerData.Trim())
                        return AnswerResult.Max;
                    return AnswerResult.Min;

                //case 4: //compare


                default: return AnswerResult.Min;



            }
        }

        public AnswerResult CompareAnswer(Question qst, Test test, string userId, string[] AnsData)
        {
            switch (qst.Type)
            {

                case QuestionsTypes.Тестовый:  //single
                    if (AnsData[0] == qst.AnswerData)
                        return AnswerResult.Max;
                    return AnswerResult.Min;

                case QuestionsTypes.НесколькоВариатов:  //multiple
                    //string[] mas1 = AnsData.Split(',');
                    string[] mas2 = qst.AnswerData.Split(',');
                    bool isSubset = mas2.All(elem => AnsData.Contains(elem));
                    if (isSubset)
                        return AnswerResult.Max;

                    int k = 0;
                    foreach (var element in AnsData)
                    {
                        if (mas2.Contains(element))
                        {
                            k++;
                            break;
                        }
                    }
                    if (k > 0)
                        return AnswerResult.Half;

                    return AnswerResult.Min;

                case QuestionsTypes.Текстовый: //text
                    if (AnsData[0].Trim().ToLower() == qst.AnswerData.Trim().ToLower())
                        return AnswerResult.Max;
                    return AnswerResult.Min;

                case QuestionsTypes.Порядок: //order
                    if (AnsData.SequenceEqual(qst.AnswerData.Split(',')))
                        return AnswerResult.Max;
                    return AnswerResult.Min;
                default: return AnswerResult.Min;



            }
        }

        public List<AnswersOption> GetAnswerOptions(Question qst)
        {
            var list = _dbContext.AnswersOptions.GetAll();
           return _dbContext.AnswersOptions.GetAll().Where(x => x.QuestionId == qst.Id).ToList();
        }
        public string[] GetAnswerOptionsStrings(Question qst)
        {
            List<string> mas=new List<string>();
            var list = _dbContext.AnswersOptions.GetAll().Where(x => x.QuestionId == qst.Id).ToList();
            foreach (var obj in list)
                mas.Add(obj.Text);
            return mas.ToArray();

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
            qst.AnswerOptionsAmount += 1;
            _dbContext.Questions.Update(qst);
           _dbContext.AnswersOptions.Add(new AnswersOption
            {
                QuestionId = qst.Id,
                Text = text,
            });
            _dbContext.Save();
        }

        public void DeleteAnswerOption(int optId)
        {
            var obj = _dbContext.AnswersOptions.Get(optId.ToString());
            var qst = _dbContext.Questions.Get(obj.QuestionId.ToString());

            _dbContext.Questions.Attach(qst);
            qst.AnswerOptionsAmount -= 1;
            _dbContext.Questions.Update(qst);
            _dbContext.AnswersOptions.Delete(optId);
            _dbContext.Save();
        }

        public void AddUserAnswer(Question qst, Test test, string ansData, string userId, AnswerResult res)
        {
            _dbContext.UserAnswers.Add(new UserAnswer
            {
                UserId = userId,
                QuestionId = qst.Id,
                TestId = test.Id,
                Data = ansData,
                Result = res
            });
            _dbContext.Save();
        }

        public void AddUserAnswer(Question qst, Test test, string[] mas, string userId, AnswerResult res)
        {
            string answer=string.Join(",",mas);


            _dbContext.UserAnswers.Add(new UserAnswer
            {
                UserId = userId,
                QuestionId = qst.Id,
                TestId = test.Id,
                Data = answer,
                Result = res
            });
            _dbContext.Save();
        }

        public List<UserAnswer> GetUserAnswersInTest(Test test, string userId)
        {
            return _dbContext.UserAnswers.GetAll().Where(x => x.TestId == test.Id && x.UserId==userId).ToList();
        }

    }
}