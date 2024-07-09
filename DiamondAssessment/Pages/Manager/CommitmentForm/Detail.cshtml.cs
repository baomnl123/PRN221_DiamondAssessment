using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class DetailModel : PageModel
    {
        private readonly ICommitmentFormService _commitmentFormService;

        public DetailModel(ICommitmentFormService commitmentFormService)
        {
            _commitmentFormService = commitmentFormService;
        }

        public Entities.Models.CommitmentForm CommitmentForm { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {

            CommitmentForm = _commitmentFormService.FindByCondition(f => f.Id == Guid.Parse(id), false).FirstOrDefault();
            return Page();

        }
    }
}
