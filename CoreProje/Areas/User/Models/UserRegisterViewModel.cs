using System.ComponentModel.DataAnnotations;

namespace CoreProje.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Girin !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Girin !")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Resim Dosya Yolu Girin !")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Girin !")]
        [Compare("Password", ErrorMessage ="Şifreler Aynı Olmalı !")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Adresinizi Girin !")]
        public string Mail { get; set; }
    }
}
