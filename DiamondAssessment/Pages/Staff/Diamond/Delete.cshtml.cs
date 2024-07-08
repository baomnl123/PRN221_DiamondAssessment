using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond
{
    public class Delete(IDiamondDetailService diamondService) : PageModel
    {
        private readonly IDiamondDetailService _diamondService = diamondService;

        public DiamondDetail Diamond { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var diamond = await _diamondService.GetDiamondDetailAsync(id);
            if (diamond == null)
                return NotFound();

            Diamond = diamond;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var diamond = await _diamondService.GetDiamondDetailAsync(id);
            if (diamond != null)
            {
                Diamond = diamond;
                await _diamondService.DeleteAsync(Diamond);
            }

            return RedirectToPage("/Staff/Diamond/Index");
        }
    }
}
