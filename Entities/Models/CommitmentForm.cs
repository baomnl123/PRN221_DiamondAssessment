namespace Entities.Models;

public class CommitmentForm
{
    public Guid Id { get; set; }
    public Guid PaperId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDelete { get; set; }

    // Relationships
    public AssessmentPaper AssessmentPaper { get; set; } = null!;
}
