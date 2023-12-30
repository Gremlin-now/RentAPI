namespace RentAPI.Models
{
    public class Account
    {
        public int Id { get; set; } = 0;
        public string Username { get; set; }
        public string Password { get; set; }
        public double Ballance { get; set; }
        public string Role { get; set; }
        public string Refresh_token { get; set; }
    }
}
