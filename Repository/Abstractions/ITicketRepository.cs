using Entities.Models;

namespace Repository.Abstractions;

public interface ITicketRepository : IRepositoryBase<Ticket>
{
    Task<Ticket?> GetTicketByRegisterFormIdAsync(Guid registerFormId);
}