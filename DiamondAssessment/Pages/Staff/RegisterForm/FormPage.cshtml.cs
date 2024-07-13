using Entities.Models;
using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages
{
    public class FormPageModel : PageModel
    {
        private readonly IRegisterFormService _registerFormService;

        public FormPageModel(IRegisterFormService registerFormService)
        {
            _registerFormService = registerFormService;
        }

        public IList<RegisterForm> Forms { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StatusFilter { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var formsQuery = _registerFormService.FindAll().AsQueryable();

            if (!string.IsNullOrEmpty(StatusFilter))
            {
                if (Enum.TryParse(StatusFilter, out RegisterFormStatus status))
                {
                    formsQuery = formsQuery.Where(f => f.RegisterFormStatus == status);
                }
            }

            var totalForms = formsQuery.Count();
            TotalPages = (int)Math.Ceiling(totalForms / 5.0);

            if (PageNumber < 1)
            {
                PageNumber = 1;
            }
            else if (PageNumber > TotalPages)
            {
                PageNumber = TotalPages;
            }

            Forms = formsQuery.Skip((PageNumber - 1) * 5)
                .Take(5)
                .ToList();

            return Page();
        }
        public async Task<IActionResult> OnPostApproveAsync(string id)
        {
            var form = await _registerFormService
                .FindByCondition(f => f.Id == Guid.Parse(id), trackChanges: true)
                .FirstOrDefaultAsync();

            var staffId = HttpContext.Session.GetString("AccountId"); // Assuming you have staff ID in session

            await _registerFormService.ApproveForm(form, staffId);

            return RedirectToPage();
        }
    }
}
