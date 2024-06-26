using Entities.Models;
using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Guest.CreateForm;

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

        registerForm.Id = new Guid();
        registerForm.RegisterFormStatus = RegisterFormStatus.Registered;
        registerForm.IsDelete = false;
        
        await _registerFormService.Create(registerForm);

        return RedirectToPage("/Index");
            
    }
}