using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Manager.CommitmentForm
{
    public class IndexModel : PageModel
    {
        private readonly ICommitmentFormService _commitmentFormService;

        public IndexModel(ICommitmentFormService commitmentFormService)
        {
            _commitmentFormService = commitmentFormService;
        }

        public IList<Entities.Models.CommitmentForm> Commitments { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var commitmentForms = _commitmentFormService.FindAll();
            var totalcommitmentForms = commitmentForms.Count();
            TotalPages = (int)Math.Ceiling(totalcommitmentForms / 5.0);

            if (PageNumber < 1)
                PageNumber = 1;

            if (PageNumber > TotalPages)
                PageNumber = TotalPages;

            Commitments = commitmentForms.Skip((PageNumber - 1) * 5).Take(5).ToList();

            return Page();
        }
    }
}
