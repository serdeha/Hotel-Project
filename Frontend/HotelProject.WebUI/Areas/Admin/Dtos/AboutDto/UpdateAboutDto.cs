namespace HotelProject.WebUI.Areas.Admin.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = "Admin";
        public string ModifiedByName { get; set; } = "Admin";
        public string? Toptitle { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
