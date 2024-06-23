using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond
{
    public class Create : PageModel
    {
        private readonly IDiamondDetailService _service;

        public Create(IDiamondDetailService service)
        {
            _service = service;
        }

        [BindProperty]
        public Entities.Models.DiamondDetail DiamondDetail { get; set; } = default!;

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

            await _service.GetAllDiamondDetailsAsync();

            return RedirectToPage("./Index");
        }
    }
}
