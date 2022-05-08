using System.Web.Mvc;
using OnlineTestingProject.Interfaces;

namespace OnlineTestingProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IQuestionService _questionService;
        public AdminController(IQuestionService serv)
        {
            _questionService = serv;
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
    }
}