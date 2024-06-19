using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Entities.Models;
namespace DiamondAssessment.Pages.Staff.RegisterForm
{
    public class DeleteFormModel : PageModel
    {
        
        public IRegisterFormService registerForm {  get; set; }
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
