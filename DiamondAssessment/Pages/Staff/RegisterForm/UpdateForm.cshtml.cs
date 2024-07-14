using Entities.Models;
using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages
{
    public class UpdateFormModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        [BindProperty]
        public RegisterForm RegisterForm { get; set; } = default!;
        public string? accId { get; set; }
        public UpdateFormModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }
        
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _registerFormService
                .FindByCondition(e => e.Id == id, false)
                .FirstOrDefaultAsync();
            
            if (form == null)
            {
                return NotFound();
            }
            RegisterForm = form;
            return Page();
            
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
                var form = await _registerFormService
                    .FindByCondition(e => e.Id == id, false)
                    .FirstOrDefaultAsync();
                accId = HttpContext.Session.GetString("AccountId");
                RegisterForm.Id = form.Id;
                RegisterForm.StaffId = Guid.Parse(accId);
                RegisterForm.RegisterFormStatus = RegisterFormStatus.Approved;
                RegisterForm.ModifiedAt = DateTime.Now;
                RegisterForm.IsDelete = false;
            
                var isUpdated = await _registerFormService.Update(RegisterForm);
                if (!isUpdated)
                    ModelState.AddModelError("UpdateFailed", "Fail to update this form!");

            return RedirectToPage("./FormPage");
        }
    }
}
