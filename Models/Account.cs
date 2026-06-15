using TicketManager.Services;

namespace TicketManager.Models
{
    public class Account
    {
        public required int id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public List<Ticket> userTickets { get; set; }= new();
    }
}