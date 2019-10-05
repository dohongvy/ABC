using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThueXe.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập user name")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]

        public string Password { set; get; }
        [Required(ErrorMessage = "Nhớ đăng nhập")]

        public bool RememberMe { set; get; }
    }
}