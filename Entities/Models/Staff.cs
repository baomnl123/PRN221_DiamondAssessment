namespace Entities.Models;

public class Staff
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    // Relationships
    public ICollection<AssessmentPaper> AssessmentPapers { get; set; } = [];
    public ICollection<RegisterForm> RegisterForms { get; set; } = [];
    public ICollection<DiamondDetail> DiamondDetails { get; set; } = [];
}
