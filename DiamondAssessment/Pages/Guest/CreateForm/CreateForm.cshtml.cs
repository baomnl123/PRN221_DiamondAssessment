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
    }
    [BindProperty]
    public RegisterForm RegisterForm { get; set; }

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

        RegisterForm.Id = new Guid();
        RegisterForm.RegisterFormStatus = RegisterFormStatus.Registered;
        RegisterForm.IsDelete = false;
        
        await _registerFormService.Create(RegisterForm);

        return RedirectToPage("/Index");
            
    }
}