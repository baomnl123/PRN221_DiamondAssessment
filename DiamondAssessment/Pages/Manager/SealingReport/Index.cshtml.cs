using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class Index : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        public Index(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }

        public IList<Entities.Models.SealingReport> SR { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var sr = _sealingReportService.FindAll();
            var totalSr = sr.Count();
            TotalPages = (int)Math.Ceiling(totalSr / 5.0);

            if (PageNumber < 1)
                PageNumber = 1;

            if (PageNumber > TotalPages)
                PageNumber = TotalPages;

            SR = sr.Skip((PageNumber - 1) * 5).Take(5).ToList();

            return Page();
        }
    }
}
