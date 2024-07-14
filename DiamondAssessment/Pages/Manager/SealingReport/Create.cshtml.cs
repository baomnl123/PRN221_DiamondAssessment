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
        private readonly IAssessmentPaperService _assessmentPaperService;

        public Create(IAssessmentPaperService assessmentPaperService, ISealingReportService sealingReportService)
        {
            _assessmentPaperService = assessmentPaperService;
            _sealingReportService = sealingReportService;
        }

        [BindProperty(SupportsGet = true)]
        public Guid PaperId { get; set; }

        [BindProperty]
        public Entities.Models.SealingReport SealingReport { get; set; }
        

        public async Task<IActionResult> OnGetAsync(Guid PaperId)
        {
            if (PaperId == Guid.Empty)
            {
                return NotFound();
            }

            SealingReport = new Entities.Models.SealingReport
            {
                PaperId = PaperId,
                CreatedAt = DateTime.UtcNow,
                IsDelete = false
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid PaperId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SealingReport.Id = new Guid();
            SealingReport.CreatedAt = DateTime.UtcNow;
            SealingReport.ModifiedAt = DateTime.UtcNow;
            SealingReport.IsDelete = false;
            SealingReport.PaperId = PaperId;
            SealingReport.SealingReportStatus = SealingReportStatus.Pending;

            await _sealingReportService.Create(SealingReport);

            return RedirectToPage("/Staff/AssessmentPaper/Index");
        }
    }
}
