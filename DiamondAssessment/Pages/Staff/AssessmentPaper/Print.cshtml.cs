using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper;

public class Print : PageModel
{
    private readonly IAssessmentPaperService _assessmentPaperService;

    public Print(IAssessmentPaperService assessmentPaperService)
    {
        _assessmentPaperService = assessmentPaperService;
    }
        
    [BindProperty]
    public Entities.Models.AssessmentPaper Paper { get; private set; }

    public IActionResult OnGet(Guid ticketId)
    {
        var paper = _assessmentPaperService
            .FindByCondition(p => p.TicketId == ticketId, false)
            .Include(p => p.Staff)
            .Include(p => p.Ticket)
            .FirstOrDefault();
        if (paper == null)
        {
            return NotFound();
        }

        Paper = paper;
        return Page();
    }
}