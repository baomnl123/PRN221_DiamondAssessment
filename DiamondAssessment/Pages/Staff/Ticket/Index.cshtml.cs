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

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;
    public int TotalPages { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var tickets = _ticketService.FindAll();
        var totalTicket = tickets.Count;
        TotalPages = (int)Math.Ceiling(totalTicket / 5.0);

        if (PageNumber < 1)
            PageNumber = 1;

        if (PageNumber > TotalPages)
            PageNumber = TotalPages;

        Tickets = tickets.Skip((PageNumber - 1) * 5).Take(5).ToList();

        return Page();
    }
}
