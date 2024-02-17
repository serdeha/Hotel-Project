using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Dtos.SubscribeDto
{
    public class UpdateSubscribeDto
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual bool IsActive { get; set; } = true;

        [Required(ErrorMessage ="Lütfen eposta adresi giriniz.")]
        public string? Email { get; set; }
    }
}
