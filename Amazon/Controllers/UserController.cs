using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.Models.User;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amazon.Controllers
{
    public class UserController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api/user";
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel modeluser)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/Login/UserName=" + modeluser.UserName, modeluser);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var resurt = JsonConvert.DeserializeObject<int>(responseData);
                    if (resurt == 1)
                    {

                       // var User = new CustomerBUS().Find(modeluser.UserName);
                       // this.Session["Customer"] = User;
                        //return RedirectToAction("Payment", "Cart");
                        //return Redirect(Request.UrlReferrer.ToString());
                        return RedirectToAction("Index", "Home");

                    }
                    else if (resurt == 0)
                    {
                        if (modeluser.PassWord != null)
                            ModelState.AddModelError("PasswordError", "PassWord Error!!");

                    }
                    else
                    {
                        if (modeluser.UserName != null)
                            ModelState.AddModelError("UsernameError", "UserName not exist");

                    }
                    
                }
                // var resurt = bus.Login(modeluser.UserName, modeluser.PassWord);
                return View("Login");
            }
            else
                return View("Login");
        }

        [HttpGet]
        public ActionResult Regist()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Regist(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CustomerBUS customerBUS = new CustomerBUS();
        //        var result = customerBUS.checkEmail(model.Email);
        //        if (result)
        //        {
        //            if (model.Password == model.ConfirmPassword)
        //            {
        //                var cus = new Customer();
        //                cus.customer_id = customerBUS.IdRandom();
        //                cus.email_address = model.Email;
        //                cus.login_name = model.Email;
        //                cus.login_password = model.Password;
        //                cus.customer_name = model.Name;
        //                int res = customerBUS.insert(cus);

        //                if (res == 1)
        //                {

        //                    ModelState.AddModelError("Success", "Regist Success");
        //                    return RedirectToAction("Login", "User");
        //                }
        //                else
        //                    ModelState.AddModelError("RegistError", "Notification!");
        //            }
        //            else
        //                ModelState.AddModelError("ConfirmPasswordError", "Password not coincide !");

        //        }
        //        else
        //            ModelState.AddModelError("EmailError", "Email exist!");
        //    }

        //    return View("Regist");
        //}
    }
}