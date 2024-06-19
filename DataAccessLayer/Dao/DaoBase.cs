using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using DataAccessLayer.Dao.Abstractions;

namespace DataAccessLayer.Dao;

public class DaoBase<TEntity> : IDaoBase<TEntity>
    where TEntity : class
{
    private readonly RepositoryContext _repositoryContext;

    protected DaoBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    
    public IQueryable<TEntity> FindAll()
    {
        return _repositoryContext.Set<TEntity>().AsNoTracking();
    }
    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false) =>
        !trackChanges
            ? _repositoryContext.Set<TEntity>().Where(expression).AsNoTracking()
            : _repositoryContext.Set<TEntity>().Where(expression);

    public async Task<bool> Create(TEntity entity)
    {
        _repositoryContext.Set<TEntity>().Add(entity);
        return await _repositoryContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(TEntity entity)
    {
        _repositoryContext.Set<TEntity>().Entry(entity).State = EntityState.Modified;
        return await _repositoryContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(TEntity entity)
    {
        _repositoryContext.Set<TEntity>().Remove(entity);
        return await _repositoryContext.SaveChangesAsync() > 0;
    }
}