using System.ComponentModel.DataAnnotations;

namespace CashOnline.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "أدخل اسم المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "أدخل كلمه المرور")]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }


    }
}
