using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper
{
    public class Delete : PageModel
    {
        private readonly IAssessmentPaperService _assessmentPaperService;

        public Delete(IAssessmentPaperService assessmentPaperService)
        {
            _assessmentPaperService = assessmentPaperService;
        }

        [BindProperty]
        public Entities.Models.AssessmentPaper Paper { get; private set; }

        public IActionResult OnGet(Guid id)
        {
            var paper = _assessmentPaperService
                .FindByCondition(p => p.Id == id, false)
                .Include(p => p.Staff)
                .Include(p => p.Ticket)
                .FirstOrDefault();
            if (paper == null)
            {
                return NotFound();
            }

            Paper = paper;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            
            var paper = _assessmentPaperService
                .FindByCondition(p => p.Id == id, false)
                .Include(p => p.Staff)
                .Include(p => p.Ticket)
                .FirstOrDefault();
            if (paper != null)
            {
                Paper = paper;

                await _assessmentPaperService.Delete(paper);

            }

            return RedirectToPage("/Staff/AssessmentPaper/Index");
        }
    }
}