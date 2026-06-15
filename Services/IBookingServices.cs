using TicketManager.Models;

namespace TicketManager.Services;
public interface IBookingServices
{
    public bool BookTicket(int accountId, int ticketId); 
    public bool cancelBooking(int accountId, int ticketId); 
    public Ticket GetTicketById(Account account, int ticketId);
    public List<Ticket> GetTicketsByAccountId(int accountId);
    int Login(string email, string password);
    bool Register(string email, string password);
    List<Ticket> GetAvailableTickets(); 
}