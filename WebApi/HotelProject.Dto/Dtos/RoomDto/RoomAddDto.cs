using System.ComponentModel.DataAnnotations;

namespace HotelProject.Dto.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Lütfen oda numarası giriniz")]
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen oda numarası giriniz")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Lütfen odanın kaç yıldız olduğunu belirtin")]
        public int Star { get; set; }
        [Required(ErrorMessage = "Lütfen oda başlığı giriniz")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısını giriniz")]
        public string? BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen duş sayısını giriniz")]
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? Description { get; set; }
    }
}
