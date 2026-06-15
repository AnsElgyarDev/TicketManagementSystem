using TicketManager.Services;
using TicketManager.Helpers;
using Pastel;

namespace TicketManager.UI.Screens;

public class AuthScreen
{
    private readonly IBookingServices _bookingService;

    public AuthScreen(IBookingServices bookingService)
    {
        _bookingService = bookingService;
    }

    public int HandleLogin()
    {
        Console.Clear();
        Console.WriteLine("=== Login Screen ===".Pastel("#00FFFF"));

        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? "";
        if (!ValidateHelper.IsValidEmail(email)) 
        { 
            Console.WriteLine("Invalid email format!".Pastel("#FF0000")); 
            Console.ReadKey(); 
            return 0;    
        }

        Console.Write("Enter Password: ");
        string password = Console.ReadLine() ?? "";
        if (!ValidateHelper.IsStrongPassword(password)) 
        { 
            Console.WriteLine("Invalid password format!".Pastel("#FF0000")); 
            Console.ReadKey(); 
            return 0; 
        }

        int userId = _bookingService.Login(email, password); 

        if (userId != 0)
        {
            Console.WriteLine("Login successful!".Pastel("#00FF00"));
            Console.ReadKey();
            return userId; 
        }

        Console.WriteLine("Invalid Email or Password!".Pastel("#FF0000"));
        Console.ReadKey();
        return 0;
    }

    public void HandleSignUp()
    {
        Console.Clear();
        Console.WriteLine("=== Sign Up Screen ===".Pastel("#00FFFF"));

        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? "";
        if (!ValidateHelper.IsValidEmail(email)) { Console.WriteLine("Invalid email format!".Pastel("#FF0000")); Console.ReadKey(); return; }

        Console.Write("Enter Password: ");
        string password = Console.ReadLine() ?? "";
        if (!ValidateHelper.IsStrongPassword(password)) { Console.WriteLine("Invalid password format!".Pastel("#FF0000")); Console.ReadKey(); return; }

        bool success = _bookingService.Register(email, password);

        if (success) Console.WriteLine("Account created successfully! Please login.".Pastel("#00FF00"));
        else Console.WriteLine("Email already exists!".Pastel("#FF0000"));

        Console.ReadKey();
    }
}