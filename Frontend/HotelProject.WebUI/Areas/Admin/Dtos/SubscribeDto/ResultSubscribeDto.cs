namespace HotelProject.WebUI.Areas.Admin.Dtos.SubscribeDto
{
    public class ResultSubscribeDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Email { get; set; }
        public virtual bool IsActive { get; set; } = true;
    }
}
