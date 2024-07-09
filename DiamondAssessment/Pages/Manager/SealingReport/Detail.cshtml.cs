using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class DetailModel : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        public DetailModel(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }

        public Entities.Models.SealingReport SealingReport { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {

            SealingReport = _sealingReportService.FindByCondition(f => f.Id == Guid.Parse(id), false).FirstOrDefault();
            return Page();

        }
    }
}
