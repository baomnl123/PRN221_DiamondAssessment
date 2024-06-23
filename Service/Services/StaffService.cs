using System.Linq.Expressions;
using Entities.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class StaffServices : IStaffService
{
    private readonly IStaffRepository _staffRepository;

    public StaffServices(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public List<Staff> FindAll() => _staffRepository.FindAll().ToList();
    public IQueryable<Staff> FindByCondition(Expression<Func<Staff, bool>> expression, bool trackChanges)
    {
        return _staffRepository.FindByCondition(expression, trackChanges);
    }

    public Task<bool> Create(Staff entity)
    {
        return _staffRepository.Create(entity);
    }

    public Task<bool> Update(Staff entity)
    {
        return _staffRepository.Update(entity);
    }

    public Task<bool> Delete(Staff entity)
    {
        entity.IsDelete = true;
        return _staffRepository.Update(entity);
    }
}