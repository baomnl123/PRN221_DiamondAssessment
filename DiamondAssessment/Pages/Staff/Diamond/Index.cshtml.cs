using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond;

public class IndexModel(IDiamondDetailService diamondService) : PageModel
{
    public IEnumerable<DiamondDetail> Diamonds { get; set; }

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;
    public int TotalPages { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var diamonds = await diamondService.GetAllDiamondDetailsAsync();
        var totalDiamonds = diamonds.Count();
        TotalPages = (int)Math.Ceiling(totalDiamonds / 2.0);

        if (PageNumber < 1)
            PageNumber = 1;

        if (PageNumber > TotalPages)
            PageNumber = TotalPages;

        Diamonds = diamonds.Skip((PageNumber - 1) * 2).Take(2).ToList();

        return Page();
    }
}
