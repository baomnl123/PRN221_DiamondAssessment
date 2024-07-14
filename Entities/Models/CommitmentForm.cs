using Entities.Models.Enum;

namespace Entities.Models;

public class CommitmentForm
{
    public Guid Id { get; set; }
    public Guid PaperId { get; set; }
    public CommitmentFormStatus CommitmentFormStatus { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; }
    public bool IsDelete { get; set; }

    // Relationships
    public AssessmentPaper AssessmentPaper { get; set; } = null!;
}
