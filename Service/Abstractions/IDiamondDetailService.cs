using Entities.Models;

namespace Service.Abstractions;

public interface IDiamondDetailService
{
    Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync();
    Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId);
    Task<DiamondDetail?> GetDiamondDetailByTicketIdAsync(Guid ticketId);
    Task<bool> CreateAsync(DiamondDetail diamondDetail);
    Task<bool> UpdateAsync(DiamondDetail diamondDetail);
    Task<bool> DeleteAsync(DiamondDetail diamondDetail);
}
