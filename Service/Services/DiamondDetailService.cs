using Entities.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class DiamondDetailService(IDiamondDetailRepository diamondRepository)
    : IDiamondDetailService
{
    public Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync()
    {
        return diamondRepository.GetAllDiamondDetailsAsync();
    }

    public Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId)
    {
        return diamondRepository.GetDiamondDetailAsync(diamondId);
    }

    public async Task<bool> CreateAsync(DiamondDetail diamondDetail) =>
        await diamondRepository.CreateAsync(diamondDetail);

    public async Task<bool> DeleteAsync(DiamondDetail diamondDetail) {
        diamondDetail.IsDelete = true;
        return await diamondRepository.UpdateAsync(diamondDetail);
    }

    public Task<bool> UpdateAsync(DiamondDetail diamondDetail) =>
        diamondRepository.UpdateAsync(diamondDetail);
}
