using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Dtos.ServiceDto
{
    public class AddServiceDto
    {
        public string? ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığını seçiniz")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
    }
}
