using System.Linq.Expressions;
using Entities.Models;
using Repository.Abstractions;

namespace Repository.Repositories;

public class CommitmentFormRepository : ICommitmentFormRepository
{
    public IQueryable<CommitmentForm> FindAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<CommitmentForm> FindByCondition(Expression<Func<CommitmentForm, bool>> expression, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(CommitmentForm entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(CommitmentForm entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(CommitmentForm entity)
    {
        throw new NotImplementedException();
    }
}