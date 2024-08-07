using Entities.Models;
using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using System.Text;

namespace DiamondAssessment.Pages
{
    public class CreateFormModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public CreateFormModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }
        [BindProperty]
        public RegisterForm RegisterForm { get; set; } = default!;
        public string? accId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {          
                return Page();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            accId = HttpContext.Session.GetString("AccountId");
            RegisterForm.Id = new Guid();
            RegisterForm.IsDelete = false;
            RegisterForm.StaffId = Guid.Parse(accId);
            RegisterForm.RegisterFormStatus = RegisterFormStatus.Approved;
            RegisterForm.CreatedAt = DateTime.Now;
            RegisterForm.ModifiedAt = DateTime.Now;
            await _registerFormService.Create(RegisterForm);

            return RedirectToPage("/Staff/RegisterForm/FormPage");

        }
    }
}
