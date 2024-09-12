using Day4_MVC_lab7___sol___Ali_Ahmed.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4_MVC_lab7___sol___Ali_Ahmed.Controllers
{

    public class ITIController : Controller
    {
        EFcontext db = new EFcontext();


        #region Index
        // GET: ITI
        public ActionResult Index()
        {
            //ViewBag.StudentsBag = db.Students.Include(i => i.Courses);
            //ViewBag.TEST = db.Departments.Include(i => i.Courses);
            //ViewBag.Courses_ID = new SelectList(db.Courses,"ID","Name");
            //ViewBag.StudentsData = db.Students;

            //return View(db.Students.Include(i => i.Courses));
            if ((string)Session["loginFORrole"] != "user" && (string)Session["loginFORrole"] == "admin")
            {
                return View(db.Students.Include(i => i.Courses));

            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        #endregion

        #region Register

        public JsonResult IsUserExists(string email)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!db.Students.Any(x => x.Email == email), JsonRequestBehavior.AllowGet);
        }

        #region HTTP GET
        [HttpGet]
        public ActionResult Register()
        {
            return View();

            //if (Session["login_username"] == null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
        }
        #endregion
        #region HTTP POST
        [HttpPost]
        //public ActionResult Register(string email, string password, string name, string phone)

        public ActionResult Register(Student p)
        {
            if (ModelState.IsValid)
            {
                var EmailExistChecking = db.Students.FirstOrDefault(i => i.Email == p.Email);
                if (EmailExistChecking == null)
                {
                    //Student p = new Student();
                    //p.Email = email;
                    //p.Password = password;
                    //p.Name = name;
                    //p.Phone = phone;
                    p.Role = "user";
                    db.Students.Add(p);
                    db.SaveChanges();
                    Session["loginFOReid"] = p.ID;
                    Session["loginFORname"] = p.Name;
                    Session["loginFORphone"] = p.Phone;
                    Session["loginFORrole"] = p.Role;
                    Session["loginFORemail"] = p.Email;
                    //Session["loginFORpic"] = p.MyProfile;

                    return RedirectToAction("MyProfile");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        #endregion
        #endregion

        #region Login
        #region HTTP GET
        [HttpGet]
        public ActionResult Login()
        {
            Session["login_username"] = null;

            return View();
        }
        #endregion
        #region HTTP POST
        [HttpPost]
        //public ActionResult Create(int id,string name, double price)     
        public ActionResult Login(Student s)
        {

            var find_acc_result = db.Students.Where(dp_acc => dp_acc.Email == s.Email && dp_acc.Password == s.Password).ToList().FirstOrDefault();
            if (find_acc_result != null && find_acc_result.Role == "admin")
            {
                Session["login_admin"] = find_acc_result.Email;
                Session["loginFORname"] = find_acc_result.Name;
                Session["loginFORname"] = find_acc_result.Name;
                Session["loginFORphone"] = find_acc_result.Phone;
                Session["loginFORrole"] = find_acc_result.Role;
                Session["loginFORemail"] = find_acc_result.Email;
                Session["loginFOReid"] = find_acc_result.ID;
                Session["loginFORpic"] = find_acc_result.ProfilePhoto;

                Session["login_username"] = find_acc_result.Email;
                return RedirectToAction("Index");

            }
            else if ((find_acc_result != null && find_acc_result.Role == "user"))
            {

                Session["loginFORname"] = find_acc_result.Name;
                Session["loginFORphone"] = find_acc_result.Phone;
                Session["loginFORrole"] = find_acc_result.Role;
                Session["loginFORemail"] = find_acc_result.Email;
                Session["loginFORpic"] = find_acc_result.ProfilePhoto;
                Session["login_username"] = find_acc_result.Email;
                Session["loginFOReid"] = find_acc_result.ID;
                return RedirectToAction("MyCourses", "Students");


            }
            else if (find_acc_result != null)
            {
                Session["loginFORname"] = find_acc_result.Name;
                Session["loginFORpic"] = find_acc_result.ProfilePhoto;
                Session["loginFORphone"] = find_acc_result.Phone;
                Session["loginFORrole"] = find_acc_result.Role;
                Session["loginFORemail"] = find_acc_result.Email;
                Session["loginFOReid"] = find_acc_result.ID;

                Session["login_username"] = find_acc_result.Email;
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.error = "Invalid User";
                return RedirectToAction("Login");

            }





        }
        #endregion
        #endregion

        #region Delete_user
        #region HTTP GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Student p = db.Students.FirstOrDefault(i => i.ID == id);
                if (p.Email != "admin" && p.Email != "user")
                {
                    db.Students.Remove(p);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("MyProfile");
            }
        }
        #endregion
        #endregion

        #region User MyProfile

        public ActionResult MyProfile()
        {
            return View();

            //if (Session["login_username"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
        }


        #endregion

        #region Delete all users
        #region HTTP GET
        public ActionResult DeleteAll()
        {
            foreach (var item in db.Students)
            {
                if (item.Email != "admin" && item.Email != "user")
                {
                    db.Students.Remove(item);
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
        #endregion

        #region MakeAdmin
        #region HTTP GET
        [HttpGet]
        public ActionResult MakeAdminOrRemove(int id)
        {
            var find_role = db.Students.Where(s => s.ID == id).ToList().FirstOrDefault();
            if ((string)Session["loginFORrole"] == "admin" && find_role != null && find_role.Role == "user" && find_role.Email != "user")
            {
                find_role.Role = "admin";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if ((string)Session["loginFORrole"] == "admin" && find_role != null && find_role.Role == "admin" && find_role.Email != "admin")
            {
                find_role.Role = "user";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if ((string)Session["loginFORrole"] == "admin" && find_role != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion
        #endregion

        #region Update
        #region HTTP GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var p = db.Students.FirstOrDefault(i => i.ID == id);
            if (p != null && p.Email != "admin" && p.Email != "user")
            {
                if (Session["login_username"] != null && Session["login_admin"] != null)
                {
                    return View(p);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        #endregion
        #region HTTP POST
        [HttpPost]
        //public ActionResult Edit(int? id, string name, string phone, string email, string password)
        public ActionResult Edit(int? id, string name, string phone, string email, string password)
        {

            if (ModelState.IsValid)
            {

                if ((string)Session["loginFORrole"] != "user" && (string)Session["loginFORrole"] == "admin")
                {

                    Student old = db.Students.ToList().FirstOrDefault(i => i.ID == (int)id);
                    old.Name = name;
                    old.Phone = phone;
                    old.Email = email;
                    //if (password == "")
                    //{
                    //    return View();

                    //}
                    old.Password = password;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Index");
                }


            }
            else
            {
                return RedirectToAction("Login");

            }

        }
        #endregion
        #endregion


        #region Upload profile picture
        #region HTTP POST
        public ActionResult UploadProfPic( int? id,HttpPostedFileBase upload)
        {
            if ((string)Session["loginFORemail"] != "user" && (string)Session["loginFORemail"] != "admin")
            {

                if (ModelState.IsValid)

                {

                    //    foreach (var item in db.Students)
                    //{
                    //if (Convert.ToString((string)Session["loginFORemail"]) == item.Email)
                    //{
                    Student EmailExistChecking = db.Students.ToList().FirstOrDefault(i => i.ID == (int)id);
                    if (EmailExistChecking != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Img/profilepictures"), upload.FileName);
                        upload.SaveAs(path);
                        EmailExistChecking.ProfilePhoto = upload.FileName;

                        db.SaveChanges();
                        Session["loginFORpic"] = EmailExistChecking.ProfilePhoto;

                    }
                    //}

                    //}

                    return RedirectToAction("MyProfile");
                }
                return RedirectToAction("MyProfile");
            }
            return RedirectToAction("MyProfile");

        }
        #endregion
        #endregion
    }
}