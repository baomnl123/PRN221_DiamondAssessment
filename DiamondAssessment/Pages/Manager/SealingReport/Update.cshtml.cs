using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class Update : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        public Update(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }
        [BindProperty]
        public Entities.Models.SealingReport SR { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var sR = _sealingReportService
                .FindByCondition(f => f.Id == id, false)
                .FirstOrDefault();
            SR = sR;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var existSr = _sealingReportService
                .FindByCondition(f => f.Id == id, false)
                .FirstOrDefault();
            existSr.SealingReportStatus = Entities.Models.Enum.SealingReportStatus.Approved;
            SR = existSr;
            await _sealingReportService.Update(SR);
            return RedirectToPage("/Manager/SealingReport/Index");
        }
    }
}
