using System.Text.RegularExpressions;
namespace TicketManager.Helpers;

public static class ValidateHelper
{
    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
    
    public static bool IsStrongPassword(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
            return false;

        var strongPasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&_#])";

        return Regex.IsMatch(password, strongPasswordRegex);
    }
}