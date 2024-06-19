using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Admin.Account;

public class Create : PageModel
{
    private readonly IStaffService _staffService;

    public Create(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [BindProperty]
    public Entities.Models.Staff Staff { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
            
        _staffService.FindAll();

        return RedirectToPage("./Index");
    }
}