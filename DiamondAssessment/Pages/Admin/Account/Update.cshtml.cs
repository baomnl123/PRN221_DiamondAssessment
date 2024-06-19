using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Admin.Account;

public class Update : PageModel
{
    private readonly IStaffService _staffService;

    public Update(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [BindProperty]
    public Entities.Models.Staff Staff { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var staff = await _staffService
            .FindByCondition(e => e.Id == Guid.Parse(id), false)
            .FirstOrDefaultAsync();
        
        if (staff == null)
        {
            return NotFound();
        }
        Staff = staff;
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
            
        try
        {
            var isUpdated = await _staffService.Update(Staff);
            if(!isUpdated) 
                ModelState.AddModelError("UpdateFailed", "Fail to update this account!");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NewsArticleExists(Staff.Id))
            {
                return NotFound();
            }
            
            throw;
            
        }

        return RedirectToPage("./Index");
    }

    private bool NewsArticleExists(Guid? id)
    {
        return _staffService
            .FindByCondition(s => s.Id == id, false)
            .FirstOrDefault() is not null;
    }
}