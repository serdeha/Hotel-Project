using System.ComponentModel.DataAnnotations;

namespace HotelProject.Dto.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual string CreatedByName { get; set; } = "Admin";
        [Required(ErrorMessage = "Lütfen oda numarası giriniz")]
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
        [Required(ErrorMessage = "Lütfen wifi sayısını giriniz")]
        public string? Wifi { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama giriniz")]
        public string? Description { get; set; }
    }
}
