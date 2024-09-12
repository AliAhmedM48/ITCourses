using Day4_MVC_lab7___sol___Ali_Ahmed.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4_MVC_lab7___sol___Ali_Ahmed.Controllers
{
    public class StudentsController : Controller
    {
        EFcontext db = new EFcontext();

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyCourses()
        {

          
            //ViewBag.DBcourses = db.Courses;
            return View(db.Students.Include(i => i.Courses));



        }

    }
}