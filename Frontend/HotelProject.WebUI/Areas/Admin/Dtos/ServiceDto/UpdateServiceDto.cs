using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public string? ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığını seçiniz")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
    }
}
