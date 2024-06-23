using Entities.Models.Enum;

namespace Entities.Models;

public class AssessmentPaper
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid StaffId { get; set; }
    public string? PaperCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Origin { get; set; }
    public float CaratWeight { get; set; }
    public Quality Clarity { get; set; }
    public Quality Cut { get; set; }
    public Quality Proportions { get; set; }
    public GlowStrength Color { get; set; }
    public Quality Polish { get; set; }
    public Quality Symmetry { get; set; }
    public GlowStrength Fluorescence { get; set; }
    public bool IsDelete { get; set; }

    // Relationships
    public Ticket Ticket { get; set; } = null!;
    public Staff Staff { get; set; } = null!;
    public CommitmentForm CommitmentForm { get; set; } = null!;
    public SealingReport SealingReport { get; set; } = null!;
}
