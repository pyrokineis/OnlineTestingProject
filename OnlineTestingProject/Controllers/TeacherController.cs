using System.Globalization;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Microsoft.AspNet.Identity;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;
using System.Web;
using System.Linq;


namespace OnlineTestingProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private readonly ITestService _testService;
        private readonly IAnswerService _answerService;

        public TeacherController(IQuestionService serv, IGroupService gr, IUserService us, ITestService ts, IAnswerService ans)
        {
            _questionService = serv;
            _groupService = gr;
            _userService = us;
            _testService = ts;
            _answerService = ans;
        }

        // GET
        //[Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {

            var user = _userService.GetUserById(User.Identity.GetUserId());
            ViewBag.testsList = _testService.GetAllTests().Where(x => x.CreatorLogin == user.UserName);
            ViewBag.groupsList = _groupService.GetAllGroups().Where(x => x.CreatorLogin == user.UserName);

            return View();
        }

        [HttpGet]
        public ActionResult QuestionsPage()
        {
            ViewBag.qstList = _questionService.GetQuestions();

            ViewBag.qstTypes = new SelectList(_questionService.GetAllQuestionTypes(), "Id", "Name");
            //ViewBag.qstTypes = new SelectList(qstTypesList, "QuestionTypeId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(Question qst)
        {
            _questionService.AddQuestion(qst);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult AddQuestionToTest(Question qst, int testId)
        {
            var test = _testService.GetTest(testId);
            _testService.AddQuestionToTest(test, qst);

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteQstFromTest(int qstId, int testId)
        {
            _testService.DeleteQstFromTest(testId, qstId);
            return Redirect(Request.UrlReferrer.ToString());

        }

        public ActionResult AddAnswerOption(int qstId, string text)
        {
            var qst = _questionService.GetQuestion(qstId);
            _answerService.AddAnswerOption(qst, text);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteAnswerOption(int optId)
        {
           _answerService.DeleteAnswerOption(optId);
            return Redirect(Request.UrlReferrer.ToString());
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
        public ActionResult AddGroup(TeacherPageVM view)
        {
            var gr = view.group;
            gr.CreatorLogin  = _userService.GetUserById(User.Identity.GetUserId()).UserName;
            _groupService.AddGroup(gr);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGroup(int id)
        {
            _groupService.DeleteGroup(id);
            return RedirectToAction("Index");

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
        }

        public ActionResult DeleteUserFromGroup(int grId, string userId)
        {
            var user = _userService.GetUserById(User.Identity.GetUserId());
            _userService.RemoveUserToGroup(user, grId);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult AddTest(TeacherPageVM view)
        {

            var user = _userService.GetUserById(User.Identity.GetUserId());
            var test = view.test;
            view.test.CreatorLogin = user.UserName;
            _testService.AddTest(test);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTest(int id)
        {
            _testService.DeleteTest(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult TestsPage()
        {
            var user = _userService.GetUserById(User.Identity.GetUserId());
            ViewBag.testsList = _testService.GetAllTests().Where(x=>x.CreatorLogin==user.UserName);
            return View();
        }
        public ActionResult TestPage(int id)
        {
            var test = _testService.GetTest(id);
            var qsts = _testService.GetQuestionsInTest(test);
            ViewBag.usersList = _testService.GetAssignedUsers(test);
            ViewBag.groupsList = _testService.GetAssignedGroups(test);

            ViewBag.qstList = qsts;
            ViewBag.qstTypes = new SelectList(_questionService.GetAllQuestionTypes(), "Id", "Name");
            ViewBag.QstOptions = _answerService.GetAnswersOptions(qsts);

            ViewBag.test = test;

            return View();
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
