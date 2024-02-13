using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.User.Dtos.User
{
    public class UserAddDto
    {
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        public string? Lastname { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir.")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [Compare("Password",ErrorMessage ="Şifreler birbiriyle uyuşmuyor.")]
        public string? ConfirmPassword { get; set; }
    }
}
