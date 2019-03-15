//using Amazon.Areas.Admin.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Amazon.Areas.Admin.Controllers
//{
//    public class LoginController : Controller
//    {
//        // GET: Admin/Login
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Login(LoginModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var bus = new EmployeeBUS();
//                var resurt = bus.Login(model.EmployeeName, model.PassWord);
//                if (resurt == 1)
//                {
//                    Session["Employee"] = model;
//                    return RedirectToAction("Index", "HomeAdmin");
//                }
//                else if (resurt == 0)
//                {
//                    if (model.PassWord != null)
//                        ModelState.AddModelError("PasswordError", "PassWord Error!!");

//                }
//                else
//                {
//                    if (model.EmployeeName != null)
//                        ModelState.AddModelError("EmployeeNameError", "EmployeeName not exist");

//                }
//                return View("Login");
//            }
//            else
//                return View("Login");




//        }
//    }
//}