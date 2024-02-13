using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        [Required(ErrorMessage = "Lütfen oda numarası giriniz")]
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen oda fiyatını giriniz")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Lütfen odanın yıldız sayısını giriniz")]
        public int Star { get; set; }
        [Required(ErrorMessage = "Lütfen oda ismini giriniz")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak adedini giriniz")]
        public string? BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen duş adedini giriniz")]
        public string? BathCount { get; set; }
        [Required(ErrorMessage = "Lütfen var mı, yok mu belirtin")]
        public string? Wifi { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = "Admin";
        public string ModifiedByName { get; set; } = "Admin";
    }
}
