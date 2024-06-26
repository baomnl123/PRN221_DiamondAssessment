using Entities.Models.Enum;

namespace Entities.Models;

public class Ticket
{
    public Guid Id { get; set; }
    public Guid RegisterFormId { get; set; }
    public string? TicketName { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public TicketStatus TicketStatus { get; set; }
    public bool IsDelete { get; set; }

    // Relationships
    public RegisterForm RegisterForm { get; set; } = null!;
    public AssessmentPaper AssessmentPaper { get; set; } = null!;
    public ICollection<DiamondDetail> DiamondDetails { get; set; } = [];
}
