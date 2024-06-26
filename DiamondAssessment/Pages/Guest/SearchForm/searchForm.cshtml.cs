using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Entities.Models;
using System.Threading.Tasks;

namespace DiamondAssessment.Pages.Guest.SearchForm
{
    public class SearchForm : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        [BindProperty]
        public RegisterForm RegisterForm { get; set; }

        [BindProperty]
        public string EmailOrPhone { get; set; }
        
        public SearchForm(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }

        public async Task<IActionResult> OnGetAsync(string emailOrPhone)
        {
            if (!string.IsNullOrEmpty(emailOrPhone))
            {
                RegisterForm = await _registerFormService.FindByEmailOrPhone(emailOrPhone);

                if (RegisterForm == null)
                {
                    ModelState.AddModelError(string.Empty, "Register form not found.");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RegisterForm = await _registerFormService.FindByEmailOrPhone(EmailOrPhone);

            if (RegisterForm == null)
            {
                ModelState.AddModelError(string.Empty, "Register form not found.");
            }

            return Page();
        }
    }
}