using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class CreateModel : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        public CreateModel(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }

        public Entities.Models.SealingReport SealingReport { get; set; }
        public void OnGet()
        {
        }
    }
}
