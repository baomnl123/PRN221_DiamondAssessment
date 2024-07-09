using System.Linq.Expressions;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories;

public class SealingReportRepository : ISealingReportRepository
{
    private readonly ISealingReportDao _sealingReportDao;

    public SealingReportRepository(ISealingReportDao sealingReportDao)
    {
        _sealingReportDao = sealingReportDao;
    }

    public IQueryable<SealingReport> FindAll()
        => _sealingReportDao
                .FindAll()
                .Where(f => f.IsDelete == false)
                .Include(f => f.AssessmentPaper);

    public IQueryable<SealingReport> FindByCondition(Expression<Func<SealingReport, bool>> expression, bool trackChanges)
    => _sealingReportDao.FindByCondition(expression, trackChanges);

    public async Task<bool> Create(SealingReport entity)
    => await _sealingReportDao.Create(entity);

    public async Task<bool> Update(SealingReport entity)
    => await _sealingReportDao.Update(entity);

    public async Task<bool> Delete(SealingReport entity)
    => await _sealingReportDao.Delete(entity);
}