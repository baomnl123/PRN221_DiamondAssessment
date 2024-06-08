using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class RegisterForm
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }
    public string? Description { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone number is a required field.")]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is a required field.")]
    public string? Email { get; set; }
    public Guid StaffId { get; set; }
    public bool Status { get; set; }

    // Relationships
    [ForeignKey(nameof(StaffId))]
    public Staff Staff { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; } = [];
}
