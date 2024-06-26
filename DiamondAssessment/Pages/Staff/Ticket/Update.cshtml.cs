using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Ticket;

public class Update : PageModel
{
    private readonly ITicketService _ticketService;

    [BindProperty]
    public Entities.Models.Ticket Ticket { get; set; } = default!;
    public Update(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }
    
    
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
        Ticket = ticket;
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(string id)
    {
        try
        {
            var ticket = await _ticketService
                .FindByCondition(e => e.Id == Guid.Parse(id), false)
                .FirstOrDefaultAsync();
            Ticket.Id = ticket.Id;
            Ticket.RegisterFormId = ticket.RegisterFormId;
            Ticket.Name = ticket.Name;
            Ticket.Email = ticket.Email;
            Ticket.PhoneNumber = ticket.PhoneNumber;
            Ticket.TicketStatus = ticket.TicketStatus;
            Ticket.IsDelete = false;
            
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