using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amazon.Models.User
{
    public class RegisterModel
    {
        string email;
        string name;

        string password;
        string confirmPassword;
        [Required(ErrorMessage = "Email không được để trống !")]
        public string Email { get => email; set => email = value; }
        [Required(ErrorMessage = "Name không được để trống!")]
        public string Name { get => name; set => name = value; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password Length must be >=6 ")]
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
    }
}