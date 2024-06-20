using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages
{
    public class UpdateFormModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public UpdateFormModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }

        public RegisterForm registerForm { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var form = _registerFormService.FindByCondition(x => x.Id == id, true).FirstOrDefault();

            registerForm = (RegisterForm)form;
            
            return Page();
            
        }
    }
}
