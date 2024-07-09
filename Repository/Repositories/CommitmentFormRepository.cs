using System.Linq.Expressions;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories;

public class CommitmentFormRepository : ICommitmentFormRepository
{
    private readonly ICommitmentFormDao _commitmentFormDao;

    public CommitmentFormRepository(ICommitmentFormDao commitmentFormDao)
    {
        _commitmentFormDao = commitmentFormDao;
    }

    public IQueryable<CommitmentForm> FindAll()
    => _commitmentFormDao
                .FindAll()
                .Where(f => f.IsDelete == false)
                .Include(f => f.AssessmentPaper);

    public IQueryable<CommitmentForm> FindByCondition(Expression<Func<CommitmentForm, bool>> expression, bool trackChanges)
    => _commitmentFormDao.FindByCondition(expression, trackChanges);

    public async Task<bool> Create(CommitmentForm entity)
    => await _commitmentFormDao.Create(entity);

    public async Task<bool> Update(CommitmentForm entity)
    => await _commitmentFormDao.Update(entity);

    public async Task<bool> Delete(CommitmentForm entity)
    => await _commitmentFormDao.Delete(entity);
}