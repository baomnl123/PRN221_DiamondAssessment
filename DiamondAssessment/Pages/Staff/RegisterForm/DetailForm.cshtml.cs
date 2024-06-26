using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages;

public class DetailForm : PageModel
{
    private readonly ITicketService _ticketService;
    private readonly IRegisterFormService _registerFormService;

    public DetailForm(ITicketService ticketService, IRegisterFormService registerFormService)
    {
        _ticketService = ticketService;
        _registerFormService = registerFormService;
    }

    public IList<Entities.Models.Ticket> Tickets { get; set; }
    public RegisterForm Form { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        var form = FormIsExist(id);
        if (form is null)
        {
            return NotFound();
        }
        Form = form;
        Tickets = _ticketService
            .FindByCondition(t => t.RegisterFormId == Guid.Parse(id) 
                                  && t.IsDelete == false, false)
            .ToList();
        return Page();
    }

    private RegisterForm? FormIsExist(string id)
    {
        var form = _registerFormService.FindByCondition(f => f.Id == Guid.Parse(id), false).FirstOrDefault();
        return form;
    }
}