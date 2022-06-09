using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

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

            var test = _testService.GetTest(id); //get test by Id
            var qsts = _testService.GetQuestionsInTest(test);   // get all questions in test
            if (isStarted==null)
            {
                ViewBag.Qstns = qsts;

                return View(test);
            }

            if (isStarted==true)
                test.Status = Models.Enums.TestStatus.InProgress;
            _testService.Update(test);


            ViewBag.Qstns = qsts;

            ViewBag.QstOptions = _answerService.GetAnswersOptions(qsts);  //get all answer options for every question


            return View(test);

        }
    }
}