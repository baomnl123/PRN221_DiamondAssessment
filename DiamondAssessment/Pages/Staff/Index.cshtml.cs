using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff;



    public class IndexModel : PageModel
    {
        private readonly IStaffService _staffService;

        public IndexModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IList<Entities.Models.Staff> Staffs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Staffs = _staffService.FindAll();
            return Page();
        }
    }