using System.Globalization;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private readonly ITestService _testService;

        public AdminController(IQuestionService serv, IGroupService gr, IUserService us, ITestService ts)
        {
            _questionService = serv;
            _groupService = gr;
            _userService = us;
            _testService = ts;
        }

        // GET
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult QuestionsPage()
        {
            ViewBag.qstList = _questionService.GetQuestions();

            ViewBag.qstTypes = new SelectList(_questionService.GetAllQuestionTypesStrs());
            //ViewBag.qstTypes = new SelectList(qstTypesList, "QuestionTypeId", "Name");
            return View();
        }
        
        [HttpPost]
        public ActionResult AddQuestion(Question qst, string questionTypeName)
        {
            qst.Type = _questionService.FindQuestionType(questionTypeName);
            _questionService.AddQuestion(qst);
            return RedirectToAction("QuestionsPage");
        }


        public ActionResult GroupsPage()
        {
            ViewBag.groupsList = _groupService.GetAllGroups(); 
            return View();
        }

        public ActionResult GroupPage(int id)
        {
            var group = _groupService.GetGroup(id);   
            ViewBag.usersList = _groupService.GetUsersInGroup(id);
            return View(group);
        }

        [HttpPost]
        public ActionResult AddGroup(Group gr)
        {
            _groupService.AddGroup(gr);
            return RedirectToAction("GroupsPage");
        }

        public ActionResult AddUser(string userline, int grId)
        {
            var user = _userService.GetUserByUsername(userline);
            if (user == null)
                return View("Error");
            else
            {
                _userService.AddUserToGroup(user, grId);
                return Redirect(Request.UrlReferrer.ToString());
            }
            //return RedirectToAction("GroupPage", this.RouteData);
        }

        public ActionResult AddTest(Test ts)
        {
            _testService.AddTest(new Test
            {
                Name = ts.Name,
                Date = System.DateTime.Now,
            });
            return RedirectToAction("TestsPage");
        }

        [HttpGet]
        public ActionResult TestsPage()
        {
            ViewBag.testsList = _testService.GetAllTests();

            //ViewBag.qstTypes = new SelectList(qstTypesList, "QuestionTypeId", "Name");
            return View();
        }
        public ActionResult TestPage(int id)
        {
            var test = _testService.GetTest(id);
            ViewBag.usersList = _testService.GetAssignedUsers(test);
            ViewBag.groupsList = _testService.GetAssignedGroups(test);
            return View(test);
        }

        public ActionResult AssignUser(string userName, int testId)
        {
            var user = _userService.GetUserByUsername(userName);
            var test = _testService.GetTest(testId);

            if (user == null)
                return View("Error");
            else
            {
                _testService.AssignUserForTest(user, test);

                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public ActionResult AssignGroup(string groupName, int testId)
        {
            var group = _groupService.GetGroupByName(groupName);
            var test = _testService.GetTest(testId);

            if (group == null)
                return View("Error");
            else
            {
                _testService.AssignGroupForTest(group, test);

                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}