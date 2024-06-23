using System.Linq.Expressions;
using Entities.Models;

namespace Service.Abstractions;

public interface ITicketService
{
    List<Ticket> FindAll();
    IQueryable<Ticket> FindByCondition(Expression<Func<Ticket, bool>> expression, bool trackChanges);
    Task<bool> Create(Ticket entity);
    Task<bool> Update(Ticket entity);
    Task<bool> Delete(Ticket entity);
}