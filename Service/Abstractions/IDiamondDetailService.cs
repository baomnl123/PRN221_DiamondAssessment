using Entities.Models;

namespace Service.Abstractions;

public interface IDiamondDetailService
{
    Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync();
    Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId);
    Task<DiamondDetail> AddDiamondDetailAsync(DiamondDetail diamondDetail);
    Task<DiamondDetail> UpdateDiamondDetailAsync(DiamondDetail diamondDetail);
    Task DeleteDiamondDetailAsync(DiamondDetail diamondDetail);
}
