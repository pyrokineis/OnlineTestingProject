using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTestingProject.Controllers
{
    public class TeacherController : Controller
    {
        [Authorize(Roles = "Teacher, Admin")]
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

    }
}
