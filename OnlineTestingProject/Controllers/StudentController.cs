using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using OnlineTestingProject.Models.Enums;

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
        [Authorize(Roles = "Student, Admin")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var listForUser = _testService.GetTestsAssignedDirectlyToUser(userId);
            var userGroups = _groupService.GetUserGroups(userId);
            var listFoGroups = _testService.GetTestsAssignedToUsersGroups(userGroups);
            

            var resList = listForUser.Union(listFoGroups).ToList();
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
            var test = _testService.GetTest(id);        //get test by Id

            TestVM testVM = new TestVM(test);

            var qsts = _testService.GetQuestionsInTest(test);            // get all questions in test
/*            var qstsOpts = _answerService.GetAnswersOptions(qsts);   */        //get all answer options for every question

            //ViewBag.Qstns = qsts;
            //ViewBag.QstOptions = qstsOpts;  //get all answer options for every question

            string[] mas;
            foreach (Question qst in qsts)
            {
                mas = _answerService.GetAnswerOptionsStrings(qst);  //get strings of qsts options
                testVM.Add(qst, mas);
            }



            if (isStarted == null)
                return View(testVM);
            

            if (isStarted==true)
            {
                test.Status = TestStatus.InProgress;
                _testService.Update(test);
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

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}