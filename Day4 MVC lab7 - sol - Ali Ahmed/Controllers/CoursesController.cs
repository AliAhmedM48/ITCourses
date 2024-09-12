using Day4_MVC_lab7___sol___Ali_Ahmed.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace Day4_MVC_lab7___sol___Ali_Ahmed.Controllers
{
    public class CoursesController : Controller
    {
        EFcontext db = new EFcontext();

        #region GET: Courses
        // GET: Courses
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CoursesBag = db.Courses.Include(i => i.Department).Include(i => i.Students);
            //ViewBag.DeparmentsBag = db.Departments;
            return View();
        }
        #endregion

        #region To apply Courses
        public ActionResult ApplyCourse(int id)
        {
            if (ModelState.IsValid)
            {
                string ppp = Convert.ToString((string)Session["loginFORemail"]);
                Course specifiedCourse = new Course();
                specifiedCourse = db.Courses.FirstOrDefault(i => i.ID == id);
                Student Sa7bElprof = new Student();
                Sa7bElprof = db.Students.FirstOrDefault(i => i.Email == ppp);
                List<Course> ListOFCourses = new List<Course>() { };
                List<Student> ListOFStudents = new List<Student>() { };
                foreach (var item in db.Students.Include(i => i.Courses))
                {
                    if (item.Email == (string)Session["loginFORemail"])
                    {
                        item.Courses.Add(specifiedCourse);

                    }
                }
                db.SaveChanges();

                //ListOFCourses.Add(specifiedCourse);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");

            }
        }
        #endregion

        #region Delete_user
        #region HTTP GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Course p = db.Courses.FirstOrDefault(i => i.ID == id);

                foreach (var item in db.Courses.Include(i => i.Students))
                {
                    foreach (var itemSS in item.Students.ToList())
                    {
                        if (Convert.ToString((string)Session["loginFORemail"]) == itemSS.Email)
                        {
                            itemSS.Courses.Remove(p);
                        }
                    }
                }
                db.SaveChanges();
                return RedirectToAction("MyCourses", "Students");
            }
            else
            {
                return RedirectToAction("MyCourses", "Students");
            }
        }
        #endregion
        #endregion


        #region Delete all courses
        #region HTTP GET
        public ActionResult DeleteAll()
        {
            foreach (var item in db.Courses.Include(i => i.Students))
            {
                foreach (var listCourses in item.Students.ToList())
                {
                    if (Convert.ToString((string)Session["loginFORemail"]) == listCourses.Email)
                    {
                        listCourses.Courses.Clear();
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("MyCourses", "Students");
        }
        #endregion
        #endregion


    }
}