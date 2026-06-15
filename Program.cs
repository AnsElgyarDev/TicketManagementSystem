using TicketManager.Models;
using TicketManager.Repositories;
using TicketManager.Services;
using TicketManager.UI;

List<Account> accounts =
[
    new Account { id = 1, userName = "ans", email = "ans@test.com", Password = "StrongPassword1@" },
    new Account { id = 2, userName = "ahmed", email = "ahmed@test.com", Password = "StrongPassword2@" }
];

List<Ticket> availableTickets =
[
    new Ticket { 
        id = 101, 
        targetMatch = new Match { Id = 1, matchName = "Ahly vs Zamalek", matchDate = DateTime.Now.AddDays(2) } 
    },

    new Ticket { 
        id = 102, 
        targetMatch = new Match { Id = 2, matchName = "Real Madrid vs Barcelona", matchDate = DateTime.Now.AddDays(5) } 
    },
    new Ticket { 
        id = 103, 
        targetMatch = new Match { Id = 3, matchName = "Manchester City vs Liverpool", matchDate = DateTime.Now.AddDays(7) } 
    },

    new Ticket { 
        id = 104, 
        targetMatch = new Match { Id = 4, matchName = "Bayern Munich vs Borussia Dortmund", matchDate = DateTime.Now.AddDays(10) } 
    },

    new Ticket { 
        id = 105, 
        targetMatch = new Match { Id = 5, matchName = "Arsenal vs Chelsea", matchDate = DateTime.Now.AddDays(12) } 
    },

    new Ticket { 
        id = 106, 
        targetMatch = new Match { Id = 6, matchName = "Inter Milan vs AC Milan", matchDate = DateTime.Now.AddDays(15) } 
    },

    new Ticket { 
        id = 107, 
        targetMatch = new Match { Id = 7, matchName = "Egypt vs Senegal", matchDate = DateTime.Now.AddDays(20) } 
    }
];

IAccountRepository repo = new AccountRepository(accounts);

IBookingServices service = new BookingServices(availableTickets, repo);

TicketUI app = new TicketUI(service);

app.Run();