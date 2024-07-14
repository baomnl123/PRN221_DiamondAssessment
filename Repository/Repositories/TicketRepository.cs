using System.Linq.Expressions;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ITicketDao _ticketDao;

    public TicketRepository(ITicketDao ticketDao)
    {
        _ticketDao = ticketDao;
    }

    public IQueryable<Ticket> FindAll() =>
        _ticketDao
            .FindAll()
            .Where(e => e.IsDelete == false)
            .OrderByDescending(e => e.ModifiedAt > e.CreatedAt ? e.ModifiedAt : e.CreatedAt);

    public IQueryable<Ticket> FindByCondition(
        Expression<Func<Ticket, bool>> expression,
        bool trackChanges
    ) =>
        _ticketDao
            .FindByCondition(expression, trackChanges)
            .OrderByDescending(e => e.ModifiedAt > e.CreatedAt ? e.ModifiedAt : e.CreatedAt);

    public Task<bool> Create(Ticket entity) => _ticketDao.Create(entity);

    public Task<bool> Update(Ticket entity) => _ticketDao.Update(entity);

    public Task<bool> Delete(Ticket entity) => _ticketDao.Delete(entity);

    public async Task<Ticket?> GetTicketByRegisterFormIdAsync(Guid registerFormId)
    {
        return await _ticketDao
            .FindByCondition(d => d.RegisterFormId == registerFormId, false)
            .FirstOrDefaultAsync();
    }
}
