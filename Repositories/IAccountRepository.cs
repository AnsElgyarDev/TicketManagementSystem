using TicketManager.Models;

public interface IAccountRepository
{
    public List<Account> GetAllAccounts();
    public Account GetAccountById(int id);
    public Account GetAccountByEmail(string email);
    public void AddAccount(Account account);
    public void updateAccount(Account account);
    public void deleteAccount(Account account);
}