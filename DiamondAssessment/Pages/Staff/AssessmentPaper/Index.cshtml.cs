using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper;

public class Index : PageModel
{
    private readonly IAssessmentPaperService _assessmentPaperService;

    public Index(IAssessmentPaperService assessmentPaperService)
    {
        _assessmentPaperService = assessmentPaperService;
    }
    
    public IList<Entities.Models.AssessmentPaper> Papers { get; set; }
    public IList<Entities.Models.AssessmentPaper> TotalPapers { get; set; }
    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;
    public int TotalPages { get; set; }

    public IActionResult OnGet()
    {
        TotalPapers = _assessmentPaperService.FindAll();
        var totalItems = TotalPapers.Count;
        TotalPages = (int)Math.Ceiling(totalItems / 4.0);
        if (PageNumber < 1)
        {
            PageNumber = 1;
        }
        else if (PageNumber > TotalPages)
        {
            PageNumber = TotalPages;
        }

        Papers = TotalPapers
            .Skip((PageNumber - 1) * 4)
            .Take(4)
            .ToList();

        return Page();
    }
}