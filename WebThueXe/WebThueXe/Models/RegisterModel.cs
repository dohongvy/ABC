using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThueXe.Models
{
    public class RegisterModel
    {
        [Key]
        public int ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage="Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [StringLength(maximumLength:32, MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 kí tự.")]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu xác nhận không đúng.")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập tên")]

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Tỉnh/thành")]

        public int ProvinceID { get; set; }


        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]

        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số diện thoại")]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }
    }
}