using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using Entities.Models;
namespace DiamondAssessment.Pages.Staff;

    public class IndexModel(IStaffService staffService) : PageModel
    {
        public IEnumerable<Entities.Models.Staff> Staffs { get; set; }

        public void OnGet()
        {
            Staffs = staffService.GetAllStaffAsync().Result;
        }
    }