using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Ticket;

public class Detail : PageModel
{
    private readonly ITicketService _ticketService;
    private readonly IDiamondDetailService _diamondDetailService;

    public Entities.Models.Ticket Ticket { get; set; } = default!;
    public bool haveDiamond { get; set; } = false;
    public Detail(ITicketService ticketService, IDiamondDetailService diamondDetailService)
    {
        _ticketService = ticketService;
        _diamondDetailService = diamondDetailService;
    }

    public async Task OnGetAsync(Guid id)
    {
        Ticket = _ticketService
            .FindByCondition(t => t.Id == id, false)
            .FirstOrDefault();
        var diamondDetail = await _diamondDetailService.GetDiamondDetailByTicketIdAsync(id);
        if (diamondDetail is not null) haveDiamond = true;
    }
}