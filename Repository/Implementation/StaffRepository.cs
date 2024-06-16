using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories;

public class StaffRepository(IStaffDao staffDao) : IStaffRepository
{
    public async Task<Staff> AddStaffAsync(Staff staff)
    {
        if (await staffDao.Create(staff))
            return staff;

        throw new Exception("Failed to add staff");
    }

    public async Task DeleteStaffAsync(Staff staff)
    {
        await staffDao.Delete(staff);
    }

    public async Task<IEnumerable<Staff>> GetAllStaffAsync()
    {
        return await staffDao.FindAll().ToListAsync();
    }

    public async Task<Staff?> GetStaffAsync(Guid staffId)
    {
        return await staffDao
            .FindByCondition(d => d.Id == staffId, false)
            .FirstOrDefaultAsync();
    }

    public async Task<Staff> UpdateStaffAsync(Staff staff)
    {
        if (await staffDao.Update(staff))
            return staff;

        throw new Exception("Failed to update staff");
    }
}