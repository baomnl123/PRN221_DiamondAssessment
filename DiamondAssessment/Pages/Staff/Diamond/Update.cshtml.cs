using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond
{
    public class Update(IDiamondDetailService diamondService) : PageModel
    {
        private readonly IDiamondDetailService _diamondService = diamondService;

        [BindProperty]
        public DiamondDetail DiamondDetail { get; set; }
        public List<SelectListItem> QualityOptions { get; set; }
        public List<SelectListItem> GlowStrengthOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var diamond = await _diamondService.GetDiamondDetailAsync(id);

            if (diamond == null)
                return NotFound();

            DiamondDetail = diamond;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var updateResult = await _diamondService.UpdateAsync(DiamondDetail);

                if (!updateResult)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Unable to update diamond details. Please try again."
                    );
                    return Page();
                }

                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "The diamond details were modified by another user. Please reload and try again."
                );
                return Page();
            }
        }
    }
}
