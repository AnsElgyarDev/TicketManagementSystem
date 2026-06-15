namespace TicketManager.Models;
public class Ticket
{
    public required int id { get; set; }
    public Match targetMatch { get; set; }
    public DateTime bookDate { get; set; } = DateTime.Now;
}