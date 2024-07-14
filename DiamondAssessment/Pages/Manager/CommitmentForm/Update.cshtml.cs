using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class UpdateModel : PageModel
    {
        private readonly ICommitmentFormService _commitmentFormService;

        public UpdateModel(ICommitmentFormService commitmentFormService)
        {
            _commitmentFormService = commitmentFormService;
        }
        [BindProperty]
        public Entities.Models.CommitmentForm CommitmentForm { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var commitform = _commitmentFormService
                .FindByCondition(f => f.Id == id, false)
                .FirstOrDefault();
            CommitmentForm = commitform;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var existform = _commitmentFormService
                .FindByCondition(f => f.Id == id, false)
                .FirstOrDefault();
            existform.CommitmentFormStatus = Entities.Models.Enum.CommitmentFormStatus.Approved;
            CommitmentForm = existform;
            await _commitmentFormService.Update(CommitmentForm);
            return RedirectToPage("/Manager/CommitmentForm/Index");
        }
    }
}
