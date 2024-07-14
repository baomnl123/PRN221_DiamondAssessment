using System.Linq.Expressions;
using Entities.Models;
using Entities.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services
{
    public class AssessmentPaperServices : IAssessmentPaperService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IAssessmentPaperRepository _assessmentPaperRepository;
        private readonly ICommitmentFormRepository _commitmentFormRepository;
        private readonly ISealingReportRepository _sealingReportRepository;

        public AssessmentPaperServices(
            ITicketRepository ticketRepository,
            IAssessmentPaperRepository assessmentPaperRepository,
            ICommitmentFormRepository commitmentFormRepository,
            ISealingReportRepository sealingReportRepository
        )
        {
            _ticketRepository = ticketRepository;
            _assessmentPaperRepository = assessmentPaperRepository;
            _commitmentFormRepository = commitmentFormRepository;
            _sealingReportRepository = sealingReportRepository;
        }

        public List<AssessmentPaper> FindAll() => _assessmentPaperRepository.FindAll().ToList();

        public IQueryable<AssessmentPaper> FindByCondition(
            Expression<Func<AssessmentPaper, bool>> expression,
            bool trackChanges
        )
        {
            return _assessmentPaperRepository.FindByCondition(expression, trackChanges);
        }

        public Task<bool> Create(AssessmentPaper entity)
        {
            return _assessmentPaperRepository.Create(entity);
        }

        public Task<bool> Update(AssessmentPaper entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(AssessmentPaper entity)
        {
            var commitmentForm = await _commitmentFormRepository
                .FindByCondition(c => c.PaperId == entity.Id, false)
                .FirstOrDefaultAsync();
            if (commitmentForm != null)
                await _commitmentFormRepository.Delete(commitmentForm);

            var sealingReport = await _sealingReportRepository
                .FindByCondition(s => s.PaperId == entity.Id, false)
                .FirstOrDefaultAsync();
            if (sealingReport != null)
                await _sealingReportRepository.Delete(sealingReport);

            var ticket = _ticketRepository
                .FindByCondition(t => t.Id == entity.TicketId, false)
                .First();
            if (!ticket.IsDelete)
                ticket.TicketStatus = TicketStatus.Pending;

            return await _assessmentPaperRepository.Delete(entity);
        }

        public Task<AssessmentPaper?> GetAssessmentPaperByTicketId(Guid ticketId)
        {
            return _assessmentPaperRepository.GetAssessmentPaperByTicketIdAsync(ticketId);
        }
    }
}
