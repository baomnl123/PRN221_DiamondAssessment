using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly IAssessmentPaperService _assessmentPaperServices;
    public List<AssessmentPaper> listPaper { get; set; }

    public PrivacyModel(ILogger<PrivacyModel> logger, IAssessmentPaperService assessmentPaperServices)
    {
        _logger = logger;
        _assessmentPaperServices = assessmentPaperServices;
    }

    public void OnGet()
    {
        listPaper = _assessmentPaperServices.FindAll();
    }
}

