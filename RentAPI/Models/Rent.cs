namespace RentAPI.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TransportId { get; set; }
        public string TimeStart { get; set; }
        public string? TimeEnd { get; set; }
        public double PriceOfUnit { get; set; }
        public string PriceType { get; set; }
        public double? FinalPrice { get; set; }
    }
}
