namespace Entities.Models;

public class RegisterForm
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Guid StaffId { get; set; }
    public bool Status { get; set; }

    // Relationships
    public Staff Staff { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; } = [];
}
