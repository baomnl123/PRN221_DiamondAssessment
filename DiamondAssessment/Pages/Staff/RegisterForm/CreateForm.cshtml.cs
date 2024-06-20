using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages
{
    public class CreateFormModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public CreateFormModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
            registerForm = new RegisterForm();
        }
        public RegisterForm registerForm { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {          
                return Page();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {               
                return Page();
            }
            registerForm.Name = "Quang";
            registerForm.Description = "Quang";
            registerForm.Email = "Quang";
            registerForm.PhoneNumber = "Quang";
           
            await _registerFormService.Create(registerForm);

            
            return RedirectToPage("/Staff/RegisterForm/FormPage");
        }
    }
}
