using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class Detail : PageModel
    {
        private readonly ISealingReportService _sealingReportService;
        private readonly IAssessmentPaperService _assessmentPaperService;

        public Detail(ISealingReportService sealingReportService, IAssessmentPaperService assessmentPaperService)
        {
            _sealingReportService = sealingReportService;
            _assessmentPaperService = assessmentPaperService;
        }

        [BindProperty] public Entities.Models.SealingReport SealingReport { get; set; }

        [BindProperty] public AssessmentPaper Paper { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SealingReport = await _sealingReportService.FindByCondition(r => r.Id == id, false).FirstOrDefaultAsync();
            if (SealingReport == null)
            {
                return NotFound();
            }

            Paper = await _assessmentPaperService.FindByCondition(r => r.Id == SealingReport.PaperId, false)
                .FirstOrDefaultAsync();
            if (Paper == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
