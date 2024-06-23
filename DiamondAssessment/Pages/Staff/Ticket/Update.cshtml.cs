using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Ticket;

public class Update : PageModel
{
    private readonly ITicketService _ticketService;

    public Update(ITicketService ticketService)
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

        var staff = await _ticketService
            .FindByCondition(e => e.Id == Guid.Parse(id), false)
            .FirstOrDefaultAsync();
        
        if (staff == null)
        {
            return NotFound();
        }
        Ticket = staff;
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
            
        try
        {
            var isUpdated = await _ticketService.Update(Ticket);
            if(!isUpdated) 
                ModelState.AddModelError("UpdateFailed", "Fail to update this account!");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NewsArticleExists(Ticket.Id))
            {
                return NotFound();
            }
            
            throw;
            
        }

        return RedirectToPage("./Index");
    }

    private bool NewsArticleExists(Guid? id)
    {
        return _ticketService
            .FindByCondition(s => s.Id == id, false)
            .FirstOrDefault() is not null;
    }
}