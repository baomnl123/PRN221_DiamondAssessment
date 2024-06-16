using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IAssessmentPaperService _assessmentPaperServices;

    public IndexModel(ILogger<IndexModel> logger, IAssessmentPaperService assessmentPaperServices)
    {
        _logger = logger;
        _assessmentPaperServices = assessmentPaperServices;
    }

    public void OnGet()
    {
    }
}
