using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = "Admin";
        public string ModifiedByName { get; set; } = "Admin";
        [Required(ErrorMessage = "Üst başlığı giriniz")]
        public string? Toptitle { get; set; }
        [Required(ErrorMessage = "Alt başlığı giriniz")]
        public string? Subtitle { get; set; }
        [Required(ErrorMessage = "Açıklama giriniz")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Oda sayısını giriniz")]
        public int RoomCount { get; set; }
        [Required(ErrorMessage = "Yönetici sayısını giriniz")]
        public int StaffCount { get; set; }
        [Required(ErrorMessage = "Müşteri sayısını giriniz")]
        public int CustomerCount { get; set; }
    }
}
