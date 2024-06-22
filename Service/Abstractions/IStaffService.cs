using System.Linq.Expressions;
using Entities.Models;

namespace Service.Abstractions;

public interface IStaffService
{
    List<Staff> FindAll();
    IQueryable<Staff> FindByCondition(Expression<Func<Staff, bool>> expression, bool trackChanges);
    Task<bool> Create(Staff entity);
    Task<bool> Update(Staff entity);
    Task<bool> Delete(Staff entity);
    
}
