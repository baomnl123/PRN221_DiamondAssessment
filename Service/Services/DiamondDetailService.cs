using Entities.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class DiamondDetailService(IDiamondDetailRepository diamondRepository)
    : IDiamondDetailService
{
    public async Task<DiamondDetail> AddDiamondDetailAsync(DiamondDetail diamondDetail)
    {
        return await diamondRepository.AddDiamondDetailAsync(diamondDetail);
    }

    public async Task DeleteDiamondDetailAsync(DiamondDetail diamondDetail)
    {
        await diamondRepository.DeleteDiamondDetailAsync(diamondDetail);
    }

    public Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync()
    {
        return diamondRepository.GetAllDiamondDetailsAsync();
    }

    public Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId)
    {
        return diamondRepository.GetDiamondDetailAsync(diamondId);
    }

    public Task<DiamondDetail> UpdateDiamondDetailAsync(DiamondDetail diamondDetail)
    {
        return diamondRepository.UpdateDiamondDetailAsync(diamondDetail);
    }
}
