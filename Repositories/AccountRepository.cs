using TicketManager.Models;

namespace TicketManager.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new();
        
        public AccountRepository( List<Account> accounts)
        {
            this._accounts = accounts;
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public void deleteAccount(Account account)
        {
            _accounts.Remove(account);
        }
        
        public Account GetAccountByEmail(string email)
        {
            return _accounts.FirstOrDefault(acc => acc.email == email);
        }

        public Account GetAccountById(int id)
        {
            return _accounts.FirstOrDefault(acc => acc.id == id);
        }

        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public void updateAccount(Account account)
        {
            var existingAccount = _accounts.FirstOrDefault(acc => acc.id == account.id);
            if (existingAccount != null)
            {
                existingAccount.userName = account.userName;
                existingAccount.email = account.email;
                existingAccount.Password = account.Password;
            }
        }
    }
}