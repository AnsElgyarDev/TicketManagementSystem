using TicketManager.Services;
using TicketManager.UI.Screens;
using Pastel;

namespace TicketManager.UI;

public class TicketUI
{
    private readonly AuthScreen _authScreen;
    private readonly BookingScreen _bookingScreen;

    public TicketUI(IBookingServices bookingService)
    {
        _authScreen = new AuthScreen(bookingService);
        _bookingScreen = new BookingScreen(bookingService);
    }

    public void Run()
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tWelcome to Ticket Manager".Pastel("#00FF00"));
            Console.WriteLine("Choose an option:".Pastel("#00FF00"));
            Console.WriteLine("1. Login".Pastel("#00FF00"));
            Console.WriteLine("2. Sign Up".Pastel("#00FF00"));
            Console.WriteLine("3. Exit".Pastel("#FF0000"));
            Console.Write("\nYour Choice: ");

            if (!Enum.TryParse<UIAuthOption>(Console.ReadLine(), out UIAuthOption choice))
            {
                Console.WriteLine("Invalid option. Please try again.".Pastel("#FF0000"));
                Console.ReadKey();
                continue; 
            }

            if (choice == UIAuthOption.ExitUi)
            {
                Console.WriteLine("Goodbye!".Pastel("#00FFFF"));
                return;
            }

            switch (choice)
            {
                case UIAuthOption.LoginUi:
                    int loggedInUserId = _authScreen.HandleLogin();  
                    if (loggedInUserId != 0)
                    {
                        _bookingScreen.ShowDashboard(loggedInUserId);
                    }
                    break;
 
                case UIAuthOption.SignUpUi:
                    _authScreen.HandleSignUp();
                    break;
            }
        }
    }
}