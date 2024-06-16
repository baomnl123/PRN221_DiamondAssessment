using Entities.Models;

namespace Service.Abstractions;

public interface IStaffService
{
    List<Staff> FindAll();
    
}