using System.Linq.Expressions;
using Entities.Models;
using Repository.Abstractions;

namespace Repository.Repositories;

public class TicketRepository : ITicketRepository
{
    public IQueryable<Ticket> FindAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Ticket> FindByCondition(Expression<Func<Ticket, bool>> expression, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(Ticket entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Ticket entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Ticket entity)
    {
        throw new NotImplementedException();
    }
}