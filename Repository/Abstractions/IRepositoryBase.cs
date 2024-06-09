using System.Linq.Expressions;

namespace Repository.Abstractions;

public interface IRepositoryBase<TEntity>
{
    IQueryable<TEntity> FindAll();
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
    Task<bool> Create(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> Delete(TEntity entity);
    string TestRepo();
}