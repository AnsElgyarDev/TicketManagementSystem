using TicketManager.Models;
using TicketManager.Repositories;

namespace TicketManager.Services;

public class AccountServices : IAccountService
{
    private readonly IAccountRepository _accountRepo;
    public AccountServices(IAccountRepository accountRepository)
    {
        _accountRepo = accountRepository;
    }

    public bool RegisterUser(int id, string username, string password, string email)
    {
        var existingAccount = _accountRepo.GetAccountByEmail(email);
        if (existingAccount != null)
        {
            return false; // User already exists
        }

        var newAccount = new Account
        {
            id = GetNextId(),
            userName = username,
            Password = password,
            email = email
        };
        
        int GetNextId() => _accountRepo.GetAllAccounts().Max(a => a.id) + 1; // Increment the highest existing ID by 1

        _accountRepo.AddAccount(newAccount);
        return true;
    }
}