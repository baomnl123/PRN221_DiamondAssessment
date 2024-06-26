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

    [BindProperty]
    public Entities.Models.Ticket Ticket { get; set; }
    public Entities.Models.RegisterForm Form { get; set; }
    
    public Create(ITicketService ticketService, IRegisterFormService registerFormService)
    {
        _ticketService = ticketService;
        _registerFormService = registerFormService;
    }
    

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

    public async Task<IActionResult> OnPost(string? formId)
    {
        //Ticket.Name = Form.Name;
        //Ticket.PhoneNumber = Form.PhoneNumber;
        //Ticket.Email = Form.Email;
        var form = _registerFormService
            .FindByCondition(f => f.Id == Guid.Parse(formId), false)
            .FirstOrDefault();
        
        
        Ticket.RegisterFormId = form.Id;
        Ticket.TicketStatus = TicketStatus.Pending;
        Ticket.IsDelete = false;

        var isCreated = await _ticketService.Create(Ticket);
        if (!isCreated)
        {
            return Page();
        }
        return RedirectToPage("../RegisterForm/FormPage");
    }
    
}