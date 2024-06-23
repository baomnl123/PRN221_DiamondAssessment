using Bogus;
using Entities.Models;

namespace DataAccessLayer.FakeDataGenerator;

public static class TicketGenerator
{
    public static Ticket[] InitializeDataForTicket(RegisterForm[] registerForms)
    {
        return new Faker<Ticket>()
            .UseSeed(1)
            .RuleFor(ticket => ticket.Id, f => f.Random.Guid())
            .RuleFor(ticket => ticket.RegisterFormId, f => f.PickRandom(registerForms).Id)
            .RuleFor(ticket => ticket.TicketName, f => f.Lorem.Sentence())
            .RuleFor(ticket => ticket.Name, f => f.Name.FullName())
            .RuleFor(ticket => ticket.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(ticket => ticket.Email, f => f.Internet.Email())
            .RuleFor(ticket => ticket.IsDelete, f => f.Random.Bool())
            .Generate(50)
            .ToArray();
    }
}
