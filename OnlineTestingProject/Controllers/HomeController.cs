using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTestingProject.Interfaces;
using OnlineTestingProject.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

            //_questionService.AddQuestion(new Question
            //{
            //    Text="lalala",
            //    Type = _questionService.GetQuestionType(1)
            //});
            //_questionService.AddQuestion(new Question
            //{
            //    Text = "lolala",
            //    Type = _questionService.GetQuestionType(1)
            //});
            //_questionService.AddQuestion(new Question
            //{
            //    Text = "lelala",
            //    Type = _questionService.GetQuestionType(1)
            //}); ;
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