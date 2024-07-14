using Entities.Models;
using Entities.Models.Enum;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class DiamondDetailService : IDiamondDetailService
{
    private readonly IDiamondDetailRepository _diamondRepository;
    private readonly ITicketRepository _ticketRepository;

    public DiamondDetailService(IDiamondDetailRepository diamondRepository, ITicketRepository ticketRepository)
    {
        _diamondRepository = diamondRepository;
        _ticketRepository = ticketRepository;
    }

    public Task<IEnumerable<DiamondDetail>> GetAllDiamondDetailsAsync()
    {
        return _diamondRepository.GetAllDiamondDetailsAsync();
    }

    public Task<DiamondDetail?> GetDiamondDetailAsync(Guid diamondId)
    {
        return _diamondRepository.GetDiamondDetailAsync(diamondId);
    }

    public Task<DiamondDetail?> GetDiamondDetailByTicketIdAsync(Guid ticketId)
    {
        return _diamondRepository.GetDiamondDetailByTicketIdAsync(ticketId);
    }

    public async Task<bool> CreateAsync(DiamondDetail diamondDetail) =>
        await _diamondRepository.CreateAsync(diamondDetail);

    public async Task<bool> DeleteAsync(DiamondDetail diamondDetail)
    {
        var ticket = _ticketRepository
            .FindByCondition(t => t.Id == diamondDetail.TicketId, false)
            .First();
        if (!ticket.IsDelete) ticket.TicketStatus = TicketStatus.Pending;
        await _ticketRepository.Update(ticket);
        diamondDetail.IsDelete = true;
        return await _diamondRepository.UpdateAsync(diamondDetail);
    }

    public Task<bool> UpdateAsync(DiamondDetail diamondDetail) =>
        _diamondRepository.UpdateAsync(diamondDetail);
}
