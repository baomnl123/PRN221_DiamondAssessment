using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class DiamondDetailService : IDiamondDetailService
{
    private readonly IDiamondDetailRepository _diamondRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IAssessmentPaperRepository _assessmentPaperRepository;
    private readonly ICommitmentFormRepository _commitmentFormRepository;
    private readonly ISealingReportRepository _sealingReportRepository;

    public DiamondDetailService(
        IDiamondDetailRepository diamondRepository,
        ITicketRepository ticketRepository,
        IAssessmentPaperRepository assessmentPaperRepository,
        ICommitmentFormRepository commitmentFormRepository,
        ISealingReportRepository sealingReportRepository
    )
    {
        _diamondRepository = diamondRepository;
        _ticketRepository = ticketRepository;
        _assessmentPaperRepository = assessmentPaperRepository;
        _commitmentFormRepository = commitmentFormRepository;
        _sealingReportRepository = sealingReportRepository;
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
        var ticket = await _ticketRepository
            .FindByCondition(t => t.Id == diamondDetail.TicketId, false)
            .FirstAsync();
        if (!ticket.IsDelete)
            ticket.TicketStatus = TicketStatus.Pending;

        await _ticketRepository.Update(ticket);

        var assessmentPaper = await _assessmentPaperRepository.GetAssessmentPaperByTicketIdAsync(
            ticket.Id
        );
        if (assessmentPaper != null)
        {
            await _assessmentPaperRepository.Delete(assessmentPaper);

            var commitmentForm = await _commitmentFormRepository
                .FindByCondition(c => c.PaperId == assessmentPaper.Id, false)
                .FirstOrDefaultAsync();
            if (commitmentForm != null)
                await _commitmentFormRepository.Delete(commitmentForm);

            var sealingReport = await _sealingReportRepository
                .FindByCondition(s => s.PaperId == assessmentPaper.Id, false)
                .FirstOrDefaultAsync();
            if (sealingReport != null)
                await _sealingReportRepository.Delete(sealingReport);
        }

        return await _diamondRepository.DeleteAsync(diamondDetail);
    }

    public Task<bool> UpdateAsync(DiamondDetail diamondDetail) =>
        _diamondRepository.UpdateAsync(diamondDetail);
}
