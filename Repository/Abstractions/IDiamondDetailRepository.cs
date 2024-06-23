using Entities.Models;

namespace Repository.Abstractions;

public interface IDiamondDetailRepository
{
    Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync();
    Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId);
    Task<bool> CreateAsync(DiamondDetail diamondDetail);
    Task<bool> UpdateAsync(DiamondDetail diamondDetail);
    Task<bool> DeleteAsync(DiamondDetail diamondDetail);
}
