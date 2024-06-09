namespace Entities.Models;

public class AssessmentPaper
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid StaffId { get; set; }
    public string? PaperCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Origin { get; set; }
    public string? Measurement { get; set; }
    public string? CaratWeight { get; set; }
    public string? Clarity { get; set; }
    public string? Cut { get; set; }
    public string? Proportions { get; set; }
    public string? Color { get; set; }
    public string? Polish { get; set; }
    public string? Symmetry { get; set; }
    public string? Fluorescence { get; set; }
    public bool Status { get; set; }

    // Relationships
    public Ticket Ticket { get; set; } = null!;
    public Staff Staff { get; set; } = null!;
    public CommitmentForm CommitmentForm { get; set; } = null!;
    public SealingReport SealingReport { get; set; } = null!;
}
