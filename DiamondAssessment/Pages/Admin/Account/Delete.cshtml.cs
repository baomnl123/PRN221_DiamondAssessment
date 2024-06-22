using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Admin.Account;

public class Delete : PageModel
{
    private readonly IStaffService _staffService;

    public Delete(IStaffService staffService)
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

        var staff = await _staffService.FindByCondition(e => e.Id == Guid.Parse(id), false).FirstOrDefaultAsync();

        if (staff == null)
        {
            return NotFound();
        }
        else
        {
            Staff = staff;
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var staff = await _staffService
            .FindByCondition(e => e.Id == Guid.Parse(id), false)
            .FirstOrDefaultAsync();
        if (staff != null)
        {
            Staff = staff;
            var isDeleted = await _staffService.Delete(Staff);
            if (!isDeleted)
            {
                ModelState.AddModelError("DeleteFailed", "Fail to delete this account!");
            }
        }

        return RedirectToPage("./Index");
    }
}