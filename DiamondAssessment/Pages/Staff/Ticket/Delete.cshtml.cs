using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Ticket;

public class Delete : PageModel
{
    private readonly ITicketService _ticketService;

    public Delete(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [BindProperty]
    public Entities.Models.Ticket Ticket { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticket = await _ticketService
            .FindByCondition(e => e.Id == Guid.Parse(id), false)
            .FirstOrDefaultAsync();

        if (ticket == null)
        {
            return NotFound();
        }
        else
        {
            Ticket = ticket;
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var staff = await _ticketService
            .FindByCondition(e => e.Id == Guid.Parse(id), false)
            .FirstOrDefaultAsync();
        if (staff != null)
        {
            Ticket = staff;
            var isDeleted = await _ticketService.Delete(Ticket);
            if (!isDeleted)
            {
                ModelState.AddModelError("DeleteFailed", "Fail to delete this account!");
            }
        }

        return RedirectToPage("./Index");
    }
}