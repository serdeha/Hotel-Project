using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Areas.Admin.Dtos.VideoDto
{
    public class UpdateVideoDto
    {
        public virtual int Id { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        [Required(ErrorMessage ="Başlık giriniz")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Alt başlık giriniz")]
        public string? Subtitle { get; set; }
        [Required(ErrorMessage = "Açıklama giriniz")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Video kaynak adresi giriniz")]
        public string? VideoSource { get; set; }
    }
}
