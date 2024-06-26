using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Ticket;

public class Create : PageModel
{
    private readonly ITicketService _ticketService;
    private readonly IRegisterFormService _registerFormService;

    public Create(ITicketService ticketService, IRegisterFormService registerFormService)
    {
        _ticketService = ticketService;
        _registerFormService = registerFormService;
    }
    
    [BindProperty]
    public Entities.Models.Ticket Ticket { get; set; }
    [BindProperty]
    public Entities.Models.RegisterForm Form { get; set; }

    public IActionResult OnGet(string? formId)
    {
        if (formId is null)
        {
            return NotFound();
        }
        
        var form = _registerFormService
            .FindByCondition(f => f.Id == Guid.Parse(formId), false)
            .FirstOrDefault();
        if (form is null)
        {
            return NotFound();
        }
        
        Form = form;
        return Page();
    }

    public IActionResult OnPost()
    {
        Ticket.RegisterFormId = Form.Id;
        Ticket.Name = Form.Name;
        Ticket.PhoneNumber = Form.PhoneNumber;
        Ticket.Email = Form.Email;
        Ticket.TicketStatus = TicketStatus.Pending;
        Ticket.IsDelete = false;

        _ticketService.Create(Ticket);
        return RedirectToPage("../RegisterForm/FormPage");
    }
    
}