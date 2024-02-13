namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class ResultRoomDto
    {
        public int Id { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        public decimal? Price { get; set; }
        public int Star { get; set; }
        public string? Title { get; set; }
        public string? BedCount { get; set; }
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? Description { get; set; }
    }
}
