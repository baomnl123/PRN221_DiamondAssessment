using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class SealingReportDao : DaoBase<SealingReport> , ISealingReportDao
{
    public SealingReportDao(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}