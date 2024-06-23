using DataAccessLayer.Context;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class SealingReportDao : DaoBase<SealingReport>
{
    protected SealingReportDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}