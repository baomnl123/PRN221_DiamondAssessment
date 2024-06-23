using System.Linq.Expressions;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Repository.Abstractions;

namespace Repository.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly IStaffDao _staffDao;

    public StaffRepository(IStaffDao staffDao)
    {
        _staffDao = staffDao;
    }

    public IQueryable<Staff> FindAll() => _staffDao.FindAll().Where(e => e.IsDelete == false);

    public IQueryable<Staff> FindByCondition(Expression<Func<Staff, bool>> expression,
        bool trackChanges)
        => _staffDao.FindByCondition(expression, trackChanges);

    public async Task<bool> Create(Staff entity) => await _staffDao.Create(entity);

    public async Task<bool> Update(Staff entity) => await _staffDao.Update(entity);

    public async Task<bool> Delete(Staff entity) => await _staffDao.Delete(entity);
}
