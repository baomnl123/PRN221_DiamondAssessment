using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories;

public class DiamondDetailRepository(IDiamondDetailDao diamondDetailDao) : IDiamondDetailRepository
{
    public async Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync()
    {
        return await diamondDetailDao
            .FindAll()
            .Where(e => e.IsDelete == false)
            .OrderByDescending(e => e.ModifiedAt > e.CreatedAt ? e.ModifiedAt : e.CreatedAt)
            .ToListAsync();
    }

    public async Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId)
    {
        return await diamondDetailDao
            .FindByCondition(d => d.Id == diamondId, false)
            .FirstOrDefaultAsync();
    }

    public async Task<DiamondDetail?> GetDiamondDetailByTicketIdAsync(Guid ticketId)
    {
        return await diamondDetailDao
            .FindByCondition(d => d.TicketId == ticketId && d.IsDelete == false, false)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(DiamondDetail diamondDetail) =>
        await diamondDetailDao.Create(diamondDetail);

    public async Task<bool> UpdateAsync(DiamondDetail diamondDetail) =>
        await diamondDetailDao.Update(diamondDetail);

    public async Task<bool> DeleteAsync(DiamondDetail diamondDetail) =>
        await diamondDetailDao.Delete(diamondDetail);
}
