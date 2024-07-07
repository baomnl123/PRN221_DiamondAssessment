using Entities.Models;
using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.Diamond
{
    public class Create : PageModel
    {
        private readonly IDiamondDetailService _diamondDetailService;
        private readonly ITicketService _ticketService;
        private readonly IStaffService _staffService;

        [BindProperty]
        public DiamondDetail DiamondDetail { get; set; }

        public List<SelectListItem> QualityOptions { get; set; }
        public List<SelectListItem> GlowStrengthOptions { get; set; }
        public List<SelectListItem> TicketOptions { get; set; }

        public Create(
            IDiamondDetailService diamondDetailService,
            ITicketService ticketService,
            IStaffService staffService
        )
        {
            _diamondDetailService = diamondDetailService;
            _ticketService = ticketService;
            _staffService = staffService;
        }

        public async Task<IActionResult> OnGetAsync(Guid ticketId)
        {
            QualityOptions = GetEnumSelectList<Quality>();
            GlowStrengthOptions = GetEnumSelectList<GlowStrength>();
            //TicketOptions = GetTicketSelectList();

            // if (Id == Guid.Empty)
            // {
            //     DiamondDetail = new DiamondDetail();
            //     return Page();
            // }
            DiamondDetail = new DiamondDetail
            {
                TicketId = ticketId
            };
            
            return Page();

            // DiamondDetail = await _diamondDetailService.GetDiamondDetailAsync(Id);
            // if (DiamondDetail == null)
            // {
            //     return NotFound();
            // }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid ticketId)
        {
            // if (!ModelState.IsValid)
            // {
            //     var errors = ModelState.Values.SelectMany(v => v.Errors);
            //     foreach (var error in errors)
            //     {
            //         Console.WriteLine(error.ErrorMessage);
            //     }
            //     QualityOptions = GetEnumSelectList<Quality>();
            //     GlowStrengthOptions = GetEnumSelectList<GlowStrength>();
            //     return Page();
            // }
            DiamondDetail.TicketId = ticketId;
            if (DiamondDetail.Id == Guid.Empty)
            {
                var ticket = _ticketService
                    .FindByCondition(t => t.Id == ticketId, false).FirstOrDefault();
                ticket.TicketStatus = TicketStatus.InProgress;
                var ticketUpdated = await _ticketService.Update(ticket);
                if (ticketUpdated)
                {
                    var isDiamondCreated = await _diamondDetailService.CreateAsync(DiamondDetail);
                    if (!isDiamondCreated)
                    {
                        ModelState.AddModelError("Error", "Error creating diamond");
                        ticket.TicketStatus = TicketStatus.Pending;
                        await _ticketService.Update(ticket);
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Error updating ticket status");
                }
            }

            DiamondDetail.Ticket.TicketStatus = TicketStatus.InProgress;
            await _ticketService.Update(DiamondDetail.Ticket);

            return RedirectToPage("./Index");
        }

        private List<SelectListItem> GetEnumSelectList<T>()
            where T : Enum
        {
            var list = new List<SelectListItem>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                list.Add(
                    new SelectListItem
                    {
                        Text = Enum.GetName(typeof(T), value),
                        Value = ((int)value).ToString()
                    }
                );
            }
            return list;
        }

        // private List<SelectListItem> GetTicketSelectList()
        // {
        //     var tickets = _ticketService.FindAll();
        //     return tickets
        //         .Select(t => new SelectListItem { Text = t.TicketName, Value = t.Id.ToString() })
        //         .ToList();
        // }
    }
}
