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
        public StudentController(IQuestionService serv, IGroupService gr, IUserService us, ITestService ts)
        {
            _questionService = serv;
            _groupService = gr;
            _userService = us;
            _testService = ts;
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

        public ActionResult TestPage(int id)
        {
            var test = _testService.GetTest(id);
            ViewBag.Qstns = _testService.getQuestionsInTest(test);


            return View(test);
        }
    }
}