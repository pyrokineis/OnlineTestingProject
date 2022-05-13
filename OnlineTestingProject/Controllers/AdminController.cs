using System.Web.Mvc;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Models;

namespace OnlineTestingProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IGroupService _groupService;
        public AdminController(IQuestionService serv, IGroupService gr)
        {
            _questionService = serv;
            _groupService = gr;
        }
        // GET
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuestionsPage()
        {
            var list = _questionService.GetQuestions();
            return View(list);
        }

        public ActionResult GroupsPage()
        {
            var list = _groupService.GetAllGroups();
            return View(list);
        }

        public ActionResult AddGroup()
        {
            return View(new Group());
        }
    }
}