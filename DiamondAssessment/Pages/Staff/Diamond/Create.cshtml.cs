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

        public async Task<IActionResult> OnGetAsync(Guid Id)
        {
            QualityOptions = GetEnumSelectList<Quality>();
            GlowStrengthOptions = GetEnumSelectList<GlowStrength>();
            TicketOptions = GetTicketSelectList();

            if (Id == Guid.Empty)
            {
                DiamondDetail = new DiamondDetail();
                return Page();
            }

            DiamondDetail = await _diamondDetailService.GetDiamondDetailAsync(Id);
            if (DiamondDetail == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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

            if (DiamondDetail.Id == Guid.Empty)
            {
                await _diamondDetailService.CreateAsync(DiamondDetail);
            }
            else
            {
                await _diamondDetailService.UpdateAsync(DiamondDetail);
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

        private List<SelectListItem> GetTicketSelectList()
        {
            var tickets = _ticketService.FindAll();
            return tickets
                .Select(t => new SelectListItem { Text = t.TicketName, Value = t.Id.ToString() })
                .ToList();
        }
    }
}
