using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.RegisterForm
{
    public class DeleteFormModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public DeleteFormModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }

        public Entities.Models.RegisterForm registerForm {  get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
