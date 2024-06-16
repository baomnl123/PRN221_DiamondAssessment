using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Implementation;

public class DiamondDetailRepository(IDiamondDetailDao diamondDetailDao) : IDiamondDetailRepository
{
    public async Task<DiamondDetail> AddDiamondDetailAsync(DiamondDetail diamondDetail)
    {
        if (await diamondDetailDao.Create(diamondDetail))
            return diamondDetail;

        throw new Exception("Failed to add diamond detail");
    }

    public async Task DeleteDiamondDetailAsync(DiamondDetail diamondDetail)
    {
        await diamondDetailDao.Delete(diamondDetail);
    }

    public async Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync()
    {
        return await diamondDetailDao.FindAll().ToListAsync();
    }

    public async Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId)
    {
        return await diamondDetailDao
            .FindByCondition(d => d.Id == diamondId, false)
            .FirstOrDefaultAsync();
    }

    public async Task<DiamondDetail> UpdateDiamondDetailAsync(DiamondDetail diamondDetail)
    {
        if (await diamondDetailDao.Update(diamondDetail))
            return diamondDetail;

        throw new Exception("Failed to update diamond detail");
    }
}
