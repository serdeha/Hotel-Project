using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.User.Dtos.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string? Password { get; set; }
    }
}
