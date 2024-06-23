using DataAccessLayer.Context;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class TicketDao : DaoBase<Ticket>
{
    protected TicketDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}