using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amazon.Areas.Admin.Models
{
    public class LoginModel
    {
        string employeeName;
        string employeepassWord;
        [Required(ErrorMessage = "UserName không được để trống !")]

        public string EmployeeName { get => employeeName; set => employeeName = value; }
        [Required(ErrorMessage = "PassWord không được để trống !")]
        public string PassWord { get => employeepassWord; set => employeepassWord = value; }
    }
}