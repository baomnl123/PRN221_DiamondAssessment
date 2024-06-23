using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond;

public class Detail : PageModel
{
    private readonly IDiamondDetailService _diamondDetailService;

    public Detail(IDiamondDetailService diamondDetailService)
    {
        _diamondDetailService = diamondDetailService;
    }

    [BindProperty]
    public Entities.Models.DiamondDetail Diamond { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var diamond = await _diamondDetailService.GetDiamondDetailAsync(Guid.Parse(id));

        if (diamond == null)
        {
            return NotFound();
        }
        else
        {
            Diamond = diamond;
        }
        return Page();
    }
}