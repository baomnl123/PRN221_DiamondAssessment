using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class IndexModel : PageModel
    {
        public IList<Entities.Models.CommitmentForm> Commitments { get; set; }
        public void OnGet()
        {
        }
    }
}
