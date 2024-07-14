using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Profile;

public class Profile : PageModel
{
    private readonly IStaffService _staffService;

    public Profile(IStaffService staffService)
    {
        _staffService = staffService;
    }
    [BindProperty]
    public Entities.Models.Staff Staff { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var id = HttpContext.Session.GetString("AccountId");
        Staff = _staffService.FindByCondition(s => s.Id == Guid.Parse(id) , false).FirstOrDefault();
        return Page();
    }
}