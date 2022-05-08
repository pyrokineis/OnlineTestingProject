﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTestingProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [Authorize(Roles ="Student, Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}