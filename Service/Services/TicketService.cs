using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IDiamondDetailRepository _diamondDetailRepository;
    private readonly IAssessmentPaperRepository _assessmentPaperRepository;
    private readonly ICommitmentFormRepository _commitmentFormRepository;
    private readonly ISealingReportRepository _sealingReportRepository;

    public TicketService(
        ITicketRepository ticketRepository,
        IDiamondDetailRepository diamondDetailRepository,
        IAssessmentPaperRepository assessmentPaperRepository,
        ICommitmentFormRepository commitmentFormRepository,
        ISealingReportRepository sealingReportRepository
    )
    {
        _ticketRepository = ticketRepository;
        _diamondDetailRepository = diamondDetailRepository;
        _assessmentPaperRepository = assessmentPaperRepository;
        _commitmentFormRepository = commitmentFormRepository;
        _sealingReportRepository = sealingReportRepository;
    }

    public List<Ticket> FindAll() => _ticketRepository.FindAll().ToList();

    public IQueryable<Ticket> FindByCondition(
        Expression<Func<Ticket, bool>> expression,
        bool trackChanges
    ) => _ticketRepository.FindByCondition(expression, trackChanges);

    public Task<bool> Create(Ticket entity)
    {
        return _ticketRepository.Create(entity);
    }

    public Task<bool> Update(Ticket entity)
    {
        return _ticketRepository.Update(entity);
    }

    public async Task<bool> Delete(Ticket entity)
    {
        var diamond = await _diamondDetailRepository.GetDiamondDetailByTicketIdAsync(entity.Id);
        if (diamond != null)
            await _diamondDetailRepository.DeleteAsync(diamond);

        var assessmentPaper = await _assessmentPaperRepository.GetAssessmentPaperByTicketIdAsync(
            entity.Id
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

        return await _ticketRepository.Delete(entity);
    }

    public Task<Ticket?> GetTicketByRegisterFormId(Guid registerFormId)
    {
        return _ticketRepository.GetTicketByRegisterFormIdAsync(registerFormId);
    }

    public async Task<List<Ticket>> FindTicketByPhone(string phone)
    {
        // Define a predicate to match either email or phone number
        Expression<Func<Ticket, bool>> predicate = t => t.PhoneNumber == phone && !t.IsDelete;

        // Call repository method to find by condition
        return await _ticketRepository
            .FindByCondition(predicate, trackChanges: false)
            .ToListAsync();
    }

    public async Task<Guid?> GetRegisterFormIdByTicketIdAsync(Guid ticketId)
    {
        var ticket = await _ticketRepository
            .FindByCondition(t => t.Id == ticketId, trackChanges: false)
            .FirstOrDefaultAsync();

        return ticket?.RegisterFormId;
    }
}
