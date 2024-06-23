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
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            
            var form = _registerFormService.FindByCondition(x => x.Id == id, true).FirstOrDefault();
            if (form == null)
            {
                return NotFound();
            }
            else
            {
                registerForm = (RegisterForm)form;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            
            var form = _registerFormService.FindByCondition(x => x.Id == id, true).FirstOrDefault();
            if (form != null)
            {
                registerForm = form;

                await _registerFormService.Delete(registerForm);

            }

            return RedirectToPage("/Staff/RegisterForm/FormPage");
        }
    }
}
