using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond;

public class Detail : PageModel
{
    private readonly IDiamondDetailService _diamondDetailService;
    private readonly IAssessmentPaperService _assessmentPaperService;
    public Detail(IDiamondDetailService diamondDetailService, IAssessmentPaperService assessmentPaperService)
    {
        _diamondDetailService = diamondDetailService;
        _assessmentPaperService = assessmentPaperService;
    }

    [BindProperty]
    public Entities.Models.DiamondDetail Diamond { get; set; } = default!;
    public Entities.Models.AssessmentPaper Paper { get; private set; }
    public bool havePaper { get; set; } = false;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        if (id == Guid.Empty)
            return NotFound();
        var diamondDetail = await _diamondDetailService.GetDiamondDetailAsync(id);

        if (diamondDetail == null)
            return NotFound();

        var diamond = await _diamondDetailService.GetDiamondDetailAsync(id);
        var ticketId = diamondDetail.TicketId;
        var paper = await _assessmentPaperService.GetAssessmentPaperByTicketId(ticketId);
        if (paper != null)
            havePaper = true;

        if (diamond == null)
            return NotFound();
        
        Paper = paper;
        Diamond = diamond;

        return Page();
    }
}
