using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services;

namespace DiamondAssessment.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly AssessmentPaperServices _assessmentPaperServices;
    public string Test;

    public IndexModel(ILogger<IndexModel> logger, AssessmentPaperServices assessmentPaperServices)
    {
        _logger = logger;
        _assessmentPaperServices = assessmentPaperServices;
        Test = _assessmentPaperServices.TestService();
    }

    public void OnGet()
    {
    }
}
