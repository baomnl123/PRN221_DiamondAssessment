using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper;

public class Update : PageModel
{
    private readonly IAssessmentPaperService _assessmentPaperService;

    [BindProperty]
    public Entities.Models.AssessmentPaper Paper { get; set; } = default!;
    public Update(IAssessmentPaperService assessmentPaperService)
    {
        _assessmentPaperService = assessmentPaperService;
    }
    
    
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
        try
        {
            var paper = _assessmentPaperService
                .FindByCondition(p => p.Id == id, false)
                .Include(p => p.Staff)
                .Include(p => p.Ticket)
                .FirstOrDefault();
            
            
            var isUpdated = await _assessmentPaperService.Update(Paper);
            if(!isUpdated) 
                ModelState.AddModelError("UpdateFailed", "Fail to update this paper!");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NewsArticleExists(Paper.Id))
            {
                return NotFound();
            }
            
            throw;
            
        }

        return RedirectToPage("./Index");
    }

    private bool NewsArticleExists(Guid? id)
    {
        return _assessmentPaperService
            .FindByCondition(s => s.Id == id, false)
            .FirstOrDefault() is not null;
    }
}