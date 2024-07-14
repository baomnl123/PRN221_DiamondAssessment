using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class DetailModel : PageModel
    {
        private readonly ISealingReportService _sealingReportService;
        private readonly IDiamondDetailService _diamondDetailService;

        public DetailModel(ISealingReportService sealingReportService, IDiamondDetailService diamondDetailService)
        {
            _sealingReportService = sealingReportService;
            _diamondDetailService = diamondDetailService;
        }

        [BindProperty]
        public Entities.Models.SealingReport SealingReport { get; set; }

        [BindProperty]
        public DiamondDetail DiamondDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var report = await _sealingReportService.FindByCondition(r => r.Id == id, false).FirstOrDefaultAsync();
            if (report == null)
            {
                return NotFound();
            }

            SealingReport = report;

            

            return Page();
        }
    }
}
