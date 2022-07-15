using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OnlineTestingProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private readonly ITestService _testService;
        private readonly IAnswerService _answerService;
        public StudentController(IQuestionService serv, IGroupService gr, IUserService us, ITestService ts, IAnswerService ans)
        {
            _questionService = serv;
            _groupService = gr;
            _userService = us;
            _testService = ts;
            _answerService = ans;
        }

        // GET: Student
        //[Authorize(Roles = "Student, Admin")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var listForUser = _testService.GetTestsAssignedDirectlyToUser(userId);
            var userGroups = _groupService.GetUserGroups(userId);
            var listFoGroups = _testService.GetTestsAssignedToUsersGroups(userGroups);

            //new DriverManager().SetUpDriver(new ChromeConfig());

            var resList = listForUser.Union(listFoGroups).ToList();
            ViewBag.finishCount = resList.Where(x => x.Status == TestStatus.Finished).Count();
            return View(resList);
        }

        public ActionResult GroupsPage()
        {
            var userId = User.Identity.GetUserId();
            var userGroups = _groupService.GetUserGroups(userId);

            return View();
        }

        public ActionResult TestPage(int id, bool? isStarted)
        {
            var userId = User.Identity.GetUserId();
            var test = _testService.GetTest(id);        //get test by Id
            TestVM testVM = new TestVM(test);

            if (isStarted == true)
            {
                test.Status = TestStatus.InProgress;
                _testService.Update(test);
            }

            if (test.Status == TestStatus.NotStarted)
            {
                return View(testVM);
            }

            if (test.Status == TestStatus.InProgress)
            {
                var qsts = _testService.GetQuestionsInTest(test);
                List<AnswersOption> list;
                foreach (Question qst in qsts)
                {
                    list = _answerService.GetAnswerOptions(qst);  //get strings of qsts options
                    testVM.Add(qst, list);
                }
            }

            if (test.Status == TestStatus.Finished)
            {
                ViewBag.Results = _testService.GetTestResult(test, userId);
                testVM.Result = _testService.GetTestResult(test, userId);
            }
            return View(testVM);
        }

        public ActionResult TestSubmit(TestVM testVM, int testId)
        {
            var userId = User.Identity.GetUserId();
            
            var answers = testVM.Answers;
            var test = _testService.GetTest(testId);

            var questionsInTest = _testService.GetQuestionsInTest(test);


            Question question;

            AnswerResult res;

            foreach (KeyValuePair<string, string[]> entry in answers)
            {
                question = _questionService.GetQuestion(Int32.Parse(entry.Key));
                res = _answerService.CompareAnswer(question, test, userId, entry.Value);
                _answerService.AddUserAnswer(question, test, entry.Value, userId, res);
            }

           var score = _testService.GetTestScore(test, userId);
            _testService.SaveTestResults(test, userId, score);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}