namespace HotelProject.WebUI.Areas.Admin.Models.Testimonial
{
    public class TestimonialUpdateViewModel
    {
        public virtual int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
