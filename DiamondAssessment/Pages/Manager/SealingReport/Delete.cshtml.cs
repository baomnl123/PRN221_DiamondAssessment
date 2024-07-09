using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class DeleteModel : PageModel
    {
        private readonly ISealingReportService _sealingReportService;

        public DeleteModel(ISealingReportService sealingReportService)
        {
            _sealingReportService = sealingReportService;
        }

        public Entities.Models.SealingReport SealingReport { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {

            var form = _sealingReportService.FindByCondition(x => x.Id == Guid.Parse(id), true).FirstOrDefault();
            if (form == null)
            {
                return NotFound();
            }
            else
            {
                SealingReport = (Entities.Models.SealingReport)form;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {

            var form = _sealingReportService.FindByCondition(x => x.Id == id, true).FirstOrDefault();
            if (form != null)
            {
                SealingReport = form;

                await _sealingReportService.Delete(SealingReport);

            }

            return RedirectToPage("/Manager/SealingReport/Index");
        }
    }
}
