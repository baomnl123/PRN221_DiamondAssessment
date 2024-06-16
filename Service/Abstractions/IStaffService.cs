using Entities.Models;

namespace Service.Abstractions;

public interface IStaffService
{
    Task<IEnumerable<Staff>> GetAllStaffAsync();
    Task<Staff?> GetStaffAsync(Guid staffId);
    Task<Staff> AddStaffAsync(Staff staff);
    Task<Staff> UpdateStaffAsync(Staff staff);
    Task DeleteStaffAsync(Staff staff);
}