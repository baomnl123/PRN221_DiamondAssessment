using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class UpdateModel : PageModel
    {
        public Entities.Models.CommitmentForm CommitmentForm { get; set; }
        public void OnGet()
        {
        }
    }
}
