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

        [BindProperty]
        public RegisterForm RegisterForm { get; set; }
        
        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public string EmailOrPhone { get; set; }
        
        public SearchForm(IRegisterFormService registerFormService, ITicketService ticketService)
        {
            _registerFormService = registerFormService;
            _ticketService = ticketService;
        }

        public async Task<IActionResult> OnGetAsync(string emailOrPhone)
        {
            if (!string.IsNullOrEmpty(emailOrPhone))
            {
                RegisterForm = await _registerFormService.FindByPhone(emailOrPhone);
                Tickets = await _ticketService.FindTicketByPhone(emailOrPhone);
                if (Tickets == null || !Tickets.Any())
                {
                    ModelState.AddModelError(string.Empty, "No tickets found.");
                }

                if (RegisterForm == null)
                {
                    ModelState.AddModelError(string.Empty, "Register form not found.");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RegisterForm = await _registerFormService.FindByPhone(EmailOrPhone);
            if (RegisterForm == null)
            {
                ModelState.AddModelError(string.Empty, "Register form not found.");
                return Page();
            }
            
            Tickets = await _ticketService.FindTicketByPhone(EmailOrPhone);
            if (Tickets == null || !Tickets.Any())
            {
                ModelState.AddModelError(string.Empty, "No tickets found.");
                return Page();
            }

            return Page();
        }
    }
}