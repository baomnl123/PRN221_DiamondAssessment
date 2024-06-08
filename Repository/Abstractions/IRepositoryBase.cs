namespace DataAccessLayer.Abstractions;

public interface IRepositoryBase<TEntity>
{
    IQueryable<TEntity> FindAll();
}