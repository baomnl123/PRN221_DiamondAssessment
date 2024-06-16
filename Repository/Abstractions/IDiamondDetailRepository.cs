using Entities.Models;

namespace Repository.Abstractions;

public interface IDiamondDetailRepository
{
    Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync();
    Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId);
    Task<DiamondDetail> AddDiamondDetailAsync(DiamondDetail diamondDetail);
    Task<DiamondDetail> UpdateDiamondDetailAsync(DiamondDetail diamondDetail);
    Task DeleteDiamondDetailAsync(DiamondDetail diamondDetail);
}
