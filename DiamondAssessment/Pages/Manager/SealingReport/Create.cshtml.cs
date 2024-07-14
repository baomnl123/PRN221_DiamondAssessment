using Entities.Models;
using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class Create : PageModel
    {
        private readonly ISealingReportService _sealingReportService;
        public Create(ISealingReportService sealingReportService, IAssessmentPaperService assessmentPaperService)
        {
            _sealingReportService = sealingReportService;
        }
        [BindProperty]
        public Entities.Models.SealingReport SR { get; set; }
        public async Task<IActionResult> OnGetAsync(string? paperId)
        {
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(string? paperId)
        {
                     
            SR.IsDelete = false;
            SR.PaperId = Guid.Parse(paperId);
            SR.SealingReportStatus = SealingReportStatus.Pending;
            SR.CreatedAt = DateTime.Now;
            SR.ModifiedAt = DateTime.Now;
            await _sealingReportService.Create(SR);
            return RedirectToPage("/Staff/AssessmentPaper/Index");
        }
    }
}
