using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class CommitmentFormDao : DaoBase<CommitmentForm> , ICommitmentFormDao
{
    public CommitmentFormDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}