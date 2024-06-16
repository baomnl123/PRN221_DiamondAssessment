using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;

namespace DataAccessLayer.Dao;

public class DiamondDetailDao : DaoBase<DiamondDetail>, IDiamondDetailDao
{
    protected DiamondDetailDao(RepositoryContext repositoryContext)
        : base(repositoryContext) { }
}
