using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.Models.User;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Amazon.DTO;
using System.Net.Http.Headers;

namespace Amazon.Controllers
{
    public class UserController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api";
        // GET: User
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // [Route("User/Login/UserName={id:int}")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel modeluser)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/User/Login", modeluser);
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


        [HttpPost]

        public string RandomID()
        {
            Random r = new Random();
            int id = r.Next(100, 999);
            return DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + id.ToString();
        }
        public async Task<ActionResult> Regist(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
               
                    if (model.Password == model.ConfirmPassword)
                    {
                    var cus = new CustomerDTO();
                        cus.customer_id = RandomID();
                        cus.email_address = model.Email;
                        cus.login_name = model.Email;
                        cus.login_password = model.Password;
                        cus.customer_name = model.Name;               
                        HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/customer",cus );
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

                                ModelState.AddModelError("Success", "Regist Success");
                                return RedirectToAction("Login", "User");
                            }
                            else if(resurt==-1)
                            ModelState.AddModelError("EmailError", "Email is Exist");
                        else
                            ModelState.AddModelError("RegistError", "Notification!");

                    }

                      
                    }
                    else
                        ModelState.AddModelError("ConfirmPasswordError", "Password not coincide !");               
            }

            return View("Regist");
        }
    }
}