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
}