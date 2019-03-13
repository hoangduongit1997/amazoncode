using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amazon.Models.User
{
    public class LoginModel
    {
        string userName;
        string passWord;
        [Required(ErrorMessage = "UserName không được để trống !")]

        public string UserName { get => userName; set => userName = value; }
        [Required(ErrorMessage = "PassWord không được để trống !")]
        public string PassWord { get => passWord; set => passWord = value; }
    }
}