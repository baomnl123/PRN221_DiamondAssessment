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
        private readonly ITicketService _ticketService;

        [BindProperty(SupportsGet = true)]
        public List<RegisterForm> RegisterForms { get; set; }

        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public string phone { get; set; }

        public SearchForm(IRegisterFormService registerFormService, ITicketService ticketService)
        {
            _registerFormService = registerFormService;
            _ticketService = ticketService;
        }

        public async Task<IActionResult> OnGetAsync(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                RegisterForms = await _registerFormService.FindRegisterFormByPhone(phone);
                Tickets = await _ticketService.FindTicketByPhone(phone);

                if (RegisterForms == null || !RegisterForms.Any())
                {
                    ModelState.Clear(); // Clear any existing errors
                    ModelState.AddModelError(string.Empty, "No register forms found for the provided phone number.");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RegisterForms = await _registerFormService.FindRegisterFormByPhone(phone);
            Tickets = await _ticketService.FindTicketByPhone(phone);

            if (RegisterForms == null || !RegisterForms.Any())
            {
                ModelState.Clear(); 
                ModelState.AddModelError(string.Empty, "No register forms found for the provided phone number.");
            }

            return Page();
        }
    }
}