using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Services;

namespace OnlineTestingProject.Controllers
{

    public class HomeController : Controller
    {
        private readonly IQuestionService _questionService;
        public HomeController(IQuestionService serv)
        {
            _questionService = serv;
        }
        public ActionResult Index()
        {
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                _questionService.GetQuestions();
                db.AnswerTypes.Add(new AnswerType
                {
                    Name = "Testoviy"
                });
            }
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}