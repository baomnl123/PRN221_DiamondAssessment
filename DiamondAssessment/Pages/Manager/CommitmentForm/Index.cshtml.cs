using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class IndexModel : PageModel
    {
        private readonly ICommitmentFormService _commitmentFormService;

        public IndexModel(ICommitmentFormService commitmentFormService)
        {
            _commitmentFormService = commitmentFormService;
        }

        public IList<Entities.Models.CommitmentForm> Commitments { get; set; }
        public void OnGet()
        {
            Commitments = _commitmentFormService.FindAll().ToList();
        }
    }
}
