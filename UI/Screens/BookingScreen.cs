using TicketManager.Services;
using Pastel;

namespace TicketManager.UI.Screens;

public class BookingScreen
{
    private readonly IBookingServices _bookingService;

    public BookingScreen(IBookingServices bookingService)
    {
        _bookingService = bookingService;
    }

    public void ShowDashboard(int currentUserId)
    {
        bool inDashboard = true;
        while (inDashboard)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t=== Main Dashboard ===".Pastel("#00FFFF"));
            Console.WriteLine("1. Book a Ticket".Pastel("#00FF00"));
            Console.WriteLine("2. Cancel a Booking".Pastel("#00FF00"));
            Console.WriteLine("3. Logout".Pastel("#666666"));
            Console.Write("\nChoose service: ");

            if (!Enum.TryParse<UIBookingOption>(Console.ReadLine(), out UIBookingOption choice))
            {
                Console.WriteLine("Invalid option. Please try again.".Pastel("#FF0000"));
                Console.ReadKey();
                continue; 
            }

            switch (choice)
            {
                case UIBookingOption.BookTicket :
                    Console.Clear();
                Console.WriteLine("\t\t\t\t=== Available Matches ===".Pastel("#00FFFF"));
                
                var availableTickets = _bookingService.GetAvailableTickets();
                
                if (availableTickets == null || availableTickets.Count == 0)
                {
                    Console.WriteLine("Sorry, there are no matches available right now.".Pastel("#FF0000"));
                    Console.ReadKey();
                    break;
                }

                foreach (var ticket in availableTickets)
                {
                    Console.WriteLine($"[Ticket ID: {ticket.id}] | Match: {ticket.targetMatch.matchName} | Date: {ticket.targetMatch.matchDate:yyyy-MM-dd HH:mm}".Pastel("#16c966"));
                }

                Console.WriteLine("\n------------------------------------------------");
                
                Console.Write("Enter Match/Ticket ID from the list above to book: ");
                int.TryParse(Console.ReadLine(), out int chosenTicketId);
                
                bool booked = _bookingService.BookTicket(currentUserId, chosenTicketId);
                if (booked) 
                    Console.WriteLine("Ticket booked successfully!".Pastel("#00FF00"));
                else 
                    Console.WriteLine("Booking Failed! Invalid Ticket ID or already booked.".Pastel("#FF0000"));
                    
                Console.ReadKey();
                break;

                case UIBookingOption.CancelBooking:
                    Console.Clear();
                    Console.WriteLine("=== Your Booked Tickets ===".Pastel("#00FFFF"));
                    var userTickets = _bookingService.GetTicketsByAccountId(currentUserId);
                    
                    if (userTickets == null || userTickets.Count == 0)
                    {
                        Console.WriteLine("You have no booked tickets to cancel.".Pastel("#FF0000"));
                        Console.ReadKey();
                        break;
                    }
                    
                    foreach (var ticket in userTickets)
                    {
                        Console.WriteLine($"[Ticket ID: {ticket.id}] | Match: {ticket.targetMatch.matchName} | Date: {ticket.targetMatch.matchDate:yyyy-MM-dd HH:mm}".Pastel("#FFFF00"));
                    }

                    Console.Write("Enter Ticket ID to cancel: ");
                    int.TryParse(Console.ReadLine(), out int cancelTicketId);
                    
                    bool canceled = _bookingService.cancelBooking(currentUserId, cancelTicketId);
                    if (canceled) Console.WriteLine("Booking canceled successfully!".Pastel("#00FF00"));
                    else Console.WriteLine("Cancel Failed! Ticket not found in your account.".Pastel("#FF0000"));
                    Console.ReadKey();
                    break;

                case UIBookingOption.Logout:
                    inDashboard = false; 
                    break;

                default:
                    Console.WriteLine("Invalid choice!".Pastel("#FF0000"));
                    Console.ReadKey();
                    break;
            }
        }
    }
}