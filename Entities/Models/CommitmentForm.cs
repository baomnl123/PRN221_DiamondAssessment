using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class CommitmentForm
{
    [Key]
    public Guid Id { get; set; }
    public Guid PaperId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Status { get; set; }

    // Relationships
    [ForeignKey(nameof(PaperId))]
    public AssessmentPaper AssessmentPaper { get; set; } = null!;
}
