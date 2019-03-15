using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazonWebAPI.Models.ViewModel.User
{
    public class LoginModel
    {
        string userName;
        string passWord;
        

        public string UserName { get => userName; set => userName = value; }
      
        public string PassWord { get => passWord; set => passWord = value; }
    }
}