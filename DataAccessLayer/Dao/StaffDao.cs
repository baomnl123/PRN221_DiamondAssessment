using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class StaffDao : DaoBase<Staff>, IStaffDao
{
    public StaffDao(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}