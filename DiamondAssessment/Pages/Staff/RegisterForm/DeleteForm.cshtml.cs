using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Entities.Models;
namespace DiamondAssessment.Pages
{
    public class DeleteFormModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public DeleteFormModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }

        public RegisterForm registerForm {  get; set; }
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
