using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Ticket
{
    public Guid Id { get; set; }
    public Guid RegisterFormId { get; set; }

    [Required(ErrorMessage = "Ticket name is a required field.")]
    public string? TicketName { get; set; }
    public bool Status { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone number is a required field.")]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is a required field.")]
    public string? Email { get; set; }

    // Relationships
    [ForeignKey(nameof(RegisterFormId))]
    public RegisterForm RegisterForm { get; set; } = null!;
    public ICollection<DiamondDetail> DiamondDetails { get; set; } = null!;
}
