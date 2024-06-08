using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Staff
{
    public Guid Id { get; set; }

    [EnumDataType(typeof(Role))]
    public Role Role { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone number is a required field.")]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is a required field.")]
    public string? Email { get; set; }

    // Relationships
    public ICollection<AssessmentPaper> AssessmentPapers { get; set; } = [];
    public ICollection<RegisterForm> RegisterForms { get; set; } = [];
    public ICollection<DiamondDetail> DiamondDetails { get; set; } = [];
}
