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
        private readonly IUserService _userService;
        public HomeController(IQuestionService serv, IUserService us)
        {
            _userService = us;
        }
        public ActionResult Index()
        {
            var user = _userService.GetUserById(User.Identity.GetUserId());
            var userIsAdmin = User.IsInRole("Admin");
            var userIsStudent = User.IsInRole("Student");
            var userIsTeacher = User.IsInRole("Teacher");


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