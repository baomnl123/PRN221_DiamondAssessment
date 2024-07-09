using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class IndexModel : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        public IndexModel(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }

        public IList<Entities.Models.SealingReport> SealingReports { get; set; }
        public void OnGet()
        {
            SealingReports = _sealingReportService.FindAll().ToList();
        }
    }
}
