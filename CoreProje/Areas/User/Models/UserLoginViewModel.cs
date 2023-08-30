using System.ComponentModel.DataAnnotations;

namespace CoreProje.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required (ErrorMessage = "Kullanıcı adı giriniz...!")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz...!")]
        public string Password { get; set; }

    }
}
