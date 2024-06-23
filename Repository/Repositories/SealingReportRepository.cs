using System.Linq.Expressions;
using Entities.Models;
using Repository.Abstractions;

namespace Repository.Repositories;

public class SealingReportRepository : ISealingReportRepository
{
    public IQueryable<SealingReport> FindAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<SealingReport> FindByCondition(Expression<Func<SealingReport, bool>> expression, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(SealingReport entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(SealingReport entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(SealingReport entity)
    {
        throw new NotImplementedException();
    }
}