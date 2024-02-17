namespace HotelProject.WebUI.Areas.Admin.Models.Staff
{
    public class StaffUpdateViewModel
    {
        public virtual int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? StaffImage { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? FacebookLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }
    }
}
