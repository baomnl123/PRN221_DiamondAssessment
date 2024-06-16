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
        public async Task<IActionResult> OnGetAsync()
        {
            Forms = _registerFormService.FindAll();
            return Page();
        }
    }
}
