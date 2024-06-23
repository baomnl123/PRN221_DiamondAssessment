using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond
{
    public class Delete : PageModel
    {
        private readonly IDiamondDetailService _service;

        public Delete(IDiamondDetailService service)
        {
            _service = service;
        }

        [BindProperty]
        public Entities.Models.DiamondDetail DiamondDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
                return NotFound();

            var diamond = await _service.GetDiamondDetailAsync(Guid.Parse(id));

            if (diamond == null)
                return NotFound();

            DiamondDetail = diamond;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null)
                return NotFound();

            var diamond = await _service.GetDiamondDetailAsync(Guid.Parse(id));

            if (diamond != null)
            {
                DiamondDetail = diamond;
                var isDeleted = await _service.DeleteAsync(DiamondDetail);

                if (!isDeleted)
                    ModelState.AddModelError("DeleteFailed", "Fail to delete this diamond!");
            }

            return RedirectToPage("./Index");
        }
    }
}
