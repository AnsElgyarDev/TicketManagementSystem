namespace TicketManager.Services;
public interface IAccountService
{
    bool RegisterUser(int id, string username, string password, string email);
}