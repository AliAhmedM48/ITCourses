using Day4_MVC_lab7___sol___Ali_Ahmed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.ComponentModel.DataAnnotations;


namespace Day4_MVC_lab7___sol___Ali_Ahmed.Controllers
{
    public class DepartmentsController : Controller
    {
        EFcontext db = new EFcontext();

        // GET: Departments
        public ActionResult Index()
        {
            ViewBag.DepartmentsBag = db.Departments;
            return View();
        }
    }
}