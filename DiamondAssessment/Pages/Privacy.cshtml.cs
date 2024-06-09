using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services;

namespace DiamondAssessment.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly AssessmentPaperServices _assessmentPaperServices;
    public string Test { get; set; }

    public PrivacyModel(ILogger<PrivacyModel> logger, AssessmentPaperServices assessmentPaperServices)
    {
        _logger = logger;
        _assessmentPaperServices = assessmentPaperServices;
    }

    public void OnGet()
    {
        Test = _assessmentPaperServices.TestService();
    }
}

