using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class TicketDao : DaoBase<Ticket>, ITicketDao
{
    public TicketDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}