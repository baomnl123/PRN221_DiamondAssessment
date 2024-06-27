using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class IndexModel : PageModel
    {
        public IList<Entities.Models.SealingReport> SealingReports { get; set; }
        public void OnGet()
        {
        }
    }
}
