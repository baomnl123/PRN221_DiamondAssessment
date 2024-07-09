using Entities.Models.Enum;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Service.Services;
using System.Text;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class CreateModel : PageModel
    {
        private readonly ICommitmentFormService _commitmentFormService;

        public CreateModel(ICommitmentFormService commitmentFormService)
        {
            _commitmentFormService = commitmentFormService;
        }
        [BindProperty]
        public Entities.Models.CommitmentForm CommitmentForm { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            CommitmentForm.Id = new Guid();
            CommitmentForm.IsDelete = false;
            
            await _commitmentFormService.Create(CommitmentForm);
            return RedirectToPage("/Manager/CommitmentForm/Index");

        }
    }
}
