namespace RentAPI.Models
{
    public class Transport
    {
        public int Id { get; set; }
        public bool CanBeRented { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? MinutePrice { get; set; }
        public double? DayPrice { get; set;}
    }
}
