using System.Linq.Expressions;
using Entities.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public List<Ticket> FindAll() => _ticketRepository.FindAll().ToList();

    public IQueryable<Ticket> FindByCondition(Expression<Func<Ticket, bool>> expression, bool trackChanges)
        => _ticketRepository.FindByCondition(expression, trackChanges);

    public Task<bool> Create(Ticket entity)
    {
        return _ticketRepository.Create(entity);
    }

    public Task<bool> Update(Ticket entity)
    {
        return _ticketRepository.Update(entity);
    }

    public Task<bool> Delete(Ticket entity)
    {
        entity.IsDelete = true;
        return _ticketRepository.Update(entity);
    }
}