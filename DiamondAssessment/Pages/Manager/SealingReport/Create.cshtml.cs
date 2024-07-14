using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class CreateModel : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        [BindProperty(SupportsGet = true)] public Guid paperId { get; set; }
        public CreateModel(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }

        public Entities.Models.SealingReport SealingReport { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid paperId)
        {
            // Pre-populate the form with the PaperId and the current date.
            SealingReport = new Entities.Models.SealingReport
            {
                PaperId = paperId,
                CreatedAt = DateTime.UtcNow,
                IsDelete = false
            };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            SealingReport.ModifiedAt = DateTime.UtcNow;
            SealingReport.SealingReportStatus = SealingReportStatus.Pending;
            await _sealingReportService.Create(SealingReport);

            return RedirectToPage("/Staff/AssessmentPaper/Index");
        }
    }
}
