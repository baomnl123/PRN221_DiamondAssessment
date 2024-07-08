using Entities.Models;

namespace Repository.Abstractions;

public interface IAssessmentPaperRepository : IRepositoryBase<AssessmentPaper>
{
    Task<AssessmentPaper?> GetAssessmentPaperByTicketIdAsync(Guid ticketId);
}