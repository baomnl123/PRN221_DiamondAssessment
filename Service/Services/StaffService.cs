using Entities.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class StaffService(IStaffRepository staffRepository)
    : IStaffService
{
    public async Task<Staff> AddStaffAsync(Staff staff)
    {
        return await staffRepository.AddStaffAsync(staff);
    }

    public async Task DeleteStaffAsync(Staff staff)
    {
        await staffRepository.DeleteStaffAsync(staff);
    }

    public Task<IEnumerable<Staff>> GetAllStaffAsync()
    {
        return staffRepository.GetAllStaffAsync();
    }

    public Task<Staff?> GetStaffAsync(Guid staffId)
    {
        return staffRepository.GetStaffAsync(staffId);
    }

    public Task<Staff> UpdateStaffAsync(Staff staff)
    {
        return staffRepository.UpdateStaffAsync(staff);
    }
}