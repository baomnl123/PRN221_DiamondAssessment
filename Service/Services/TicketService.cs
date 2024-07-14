using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
    public Task<Ticket?> GetTicketByRegisterFormId(Guid registerFormId)
    {
        return _ticketRepository.GetTicketByRegisterFormIdAsync(registerFormId);
    }
    public async Task<List<Ticket>> FindTicketByPhone(string phone)
    {
        // Define a predicate to match either email or phone number
        Expression<Func<Ticket, bool>> predicate = 
            t => t.PhoneNumber == phone && !t.IsDelete;

        // Call repository method to find by condition
        return await _ticketRepository.FindByCondition(predicate, trackChanges: false).ToListAsync();
    }
    public async Task<Guid?> GetRegisterFormIdByTicketIdAsync(Guid ticketId)
    {
        var ticket = await _ticketRepository
            .FindByCondition(t => t.Id == ticketId, trackChanges: false)
            .FirstOrDefaultAsync();

        return ticket?.RegisterFormId;
    }
}