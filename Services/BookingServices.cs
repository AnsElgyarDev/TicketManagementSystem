using TicketManager.Models;

namespace TicketManager.Services;

public class BookingServices : IBookingServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly List<Ticket> _availableTickets;

    public BookingServices(List<Ticket> availableTickets, IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        _availableTickets = availableTickets;
    }

    public bool BookTicket(int accountId, int ticketId)
    {
            var account = _accountRepository.GetAccountById(accountId);
            
            if (account == null)
                return false;
            
            var ticket = _availableTickets.FirstOrDefault(t => t.id == ticketId);
            
            if (ticket == null)
                return false;
                
            account.userTickets.Add(ticket);
            return true;
    }

    public bool cancelBooking(int accountId, int ticketId)
    {
        var account = _accountRepository.GetAccountById(accountId);
        
        if (account == null)
            return false;

        var ticket = GetTicketById(account, ticketId);
        
        if (ticket == null )
            return false;

        account.userTickets.Remove(ticket);
        return true;
    }

    public List<Ticket> GetAvailableTickets()
    {
        return _availableTickets;
    }

    public Ticket GetTicketById(Account account, int ticketId)
    {
        return account.userTickets.FirstOrDefault(t => t.id == ticketId);
    }

    public List<Ticket> GetTicketsByAccountId(int accountId)
    {
        var account = _accountRepository.GetAccountById(accountId);
        return account?.userTickets ?? new List<Ticket>();
    }

public int Login(string email, string password)
{
    var accounts = _accountRepository.GetAllAccounts(); 
    
    var account = accounts.FirstOrDefault(a => a.email == email && a.Password == password);
    
    if (account != null) return account.id;
    
    return 0; 
}

public bool Register(string email, string password)
{
    var accounts = _accountRepository.GetAllAccounts();
    
    bool exists = accounts.Any(a => a.email == email);
    if (exists) return false; 

    var newAccount = new Account 
    { 
        id = accounts.Count + 1, 
        email = email, 
        Password = password,
        userName = email.Split('@')[0] 
    };

    _accountRepository.AddAccount(newAccount); 
    return true; 
}
}
