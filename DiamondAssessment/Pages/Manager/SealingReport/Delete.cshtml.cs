using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondAssessment.Pages.Manager.SealingReport
{
    public class DeleteModel : PageModel
    {
        public Entities.Models.SealingReport SealingReport { get; set; }
        public void OnGet()
        {
        }
    }
}
