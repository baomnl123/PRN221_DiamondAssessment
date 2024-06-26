using Entities.Models.Enum;

namespace Entities.Models;

public class Staff
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsDelete { get; set; }

    // Relationships
    public ICollection<AssessmentPaper> AssessmentPapers { get; set; } = [];
    public ICollection<RegisterForm> RegisterForms { get; set; } = [];
    public ICollection<DiamondDetail> DiamondDetails { get; set; } = [];
}
