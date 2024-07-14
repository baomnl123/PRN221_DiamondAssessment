using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Profile
{
    public class UpdateModel : PageModel
    {
        private readonly IStaffService _staffService;

        public UpdateModel(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [BindProperty]
        public Entities.Models.Staff Staff { get; set; }
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            
            Staff = _staffService.FindByCondition(s => s.Id == Guid.Parse(id), false).FirstOrDefault();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string? id)
        {
            var staff = _staffService.FindByCondition(s => s.Id == Guid.Parse(id), false).FirstOrDefault();
            Staff.Id = staff.Id;
            Staff.Role = staff.Role;
            Staff.CreatedAt = staff.CreatedAt;
            Staff.ModifiedAt = DateTime.Now;
            Staff.Password = staff.Password;
            Staff.IsDelete = staff.IsDelete;
            await _staffService.Update(Staff);
            return RedirectToPage("/Staff/Profile/Profile");
        }
    }
}
