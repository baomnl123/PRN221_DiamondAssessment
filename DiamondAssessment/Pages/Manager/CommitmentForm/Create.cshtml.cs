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
        private readonly IAssessmentPaperService _assessmentPaperService;
        public CreateModel(ICommitmentFormService commitmentFormService, IAssessmentPaperService assessmentPaperService)
        {
            _commitmentFormService = commitmentFormService;
            _assessmentPaperService = assessmentPaperService;
        }
        [BindProperty]
        public Entities.Models.CommitmentForm CommitmentForm { get; set; }
        public Entities.Models.AssessmentPaper AssessmentPaper { get; set; }
        public async Task<IActionResult> OnGetAsync(string? paperId)
        {
            //var paper = _assessmentPaperService
            //.FindByCondition(f => f.Id == Guid.Parse(paperId), false)
            //.FirstOrDefault();
            //AssessmentPaper = paper;
            return Page();

        }
        public async Task<IActionResult> OnPostAsync(string? paperId)
        {
                     
            CommitmentForm.IsDelete = false;
            CommitmentForm.PaperId = Guid.Parse(paperId);
            await _commitmentFormService.Create(CommitmentForm);
            return RedirectToPage("/Manager/CommitmentForm/Index");

        }
    }
}
