using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class DeleteModel : PageModel
    {
        private readonly ICommitmentFormService _commitmentFormService;

        public DeleteModel(ICommitmentFormService commitmentFormService)
        {
            _commitmentFormService = commitmentFormService;
        }

        public Entities.Models.CommitmentForm CommitmentForm { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {

            var form = _commitmentFormService.FindByCondition(x => x.Id == Guid.Parse(id), true).FirstOrDefault();
            if (form == null)
            {
                return NotFound();
            }
            else
            {
                CommitmentForm = (Entities.Models.CommitmentForm)form;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {

            var form = _commitmentFormService.FindByCondition(x => x.Id == id, true).FirstOrDefault();
            if (form != null)
            {
                CommitmentForm = form;

                await _commitmentFormService.Delete(CommitmentForm);

            }

            return RedirectToPage("/Manager/CommitmentForm/Index");
        }
    }
}
