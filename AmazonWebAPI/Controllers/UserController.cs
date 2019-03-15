//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using AmazonWebAPI.Services;
//using AmazonWebAPI.Models;
//using AmazonWebAPI.Models.ViewModel.User;

//namespace AmazonWebAPI.Controllers
//{
//    public class UserController : ApiController
//    {
//        UserRepository userRepository = null;
//       public UserController()
//        {
//            this.userRepository = new UserRepository();
//        }
//        [HttpPost]
//        [Route("api/User/Login/UserName={id:int}")]
//        public int Login(LoginModel loginModel)
//        {
//            return userRepository.Login(loginModel);
//        }
//    }
//}
