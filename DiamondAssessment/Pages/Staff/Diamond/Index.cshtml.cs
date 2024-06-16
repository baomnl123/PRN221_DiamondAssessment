using Entities.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Diamond;

public class IndexModel(IDiamondDetailService diamondService) : PageModel
{
    public IEnumerable<DiamondDetail> Diamonds { get; set; }

    public void OnGet()
    {
        Diamonds = diamondService.GetAllDiamondDetailsAsync().Result;
    }
}
