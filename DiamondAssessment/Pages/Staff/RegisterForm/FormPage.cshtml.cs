using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages
{
    public class FormPageModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public FormPageModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }
        public IList<RegisterForm> Forms { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var totalForms = _registerFormService.FindAll().Count;
            TotalPages = (int)Math.Ceiling(totalForms / 3.0);

            Forms = _registerFormService.FindAll()
                                         .Skip((PageNumber - 1) * 3)
                                         .Take(3)
                                         .ToList();
            return Page();
        }
    }
}
