using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Ticket;

public class Index : PageModel
{
    private readonly ITicketService _ticketService;

    public Index(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public IList<Entities.Models.Ticket> Tickets { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Tickets = _ticketService.FindAll();
        return Page();
    }
}