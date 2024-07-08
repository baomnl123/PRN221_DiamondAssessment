using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using System;
using System.Threading.Tasks;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper
{
    public class Create : PageModel
    {
        private readonly IAssessmentPaperService _assessmentPaperService;
        private readonly IDiamondDetailService _diamondDetailService;
        private readonly ITicketService _ticketService;

        public Create(IAssessmentPaperService assessmentPaperService, IDiamondDetailService diamondDetailService,
            ITicketService ticketService)
        {
            _assessmentPaperService = assessmentPaperService;
            _diamondDetailService = diamondDetailService;
            _ticketService = ticketService;
        }

        [BindProperty(SupportsGet = true)] public Guid DiamondId { get; set; }

        [BindProperty(SupportsGet = true)] public Guid TicketId { get; set; }

        [BindProperty] public Entities.Models.AssessmentPaper Paper { get; set; }

        public DiamondDetail DiamondDetail { get; private set; }
        public string? accId { get; set; }
    
        public async Task<IActionResult> OnGetAsync(Guid diamondId, Guid ticketId)
        {
            if (diamondId == Guid.Empty || ticketId == Guid.Empty)
            {
                return NotFound();
            }

            DiamondDetail = await _diamondDetailService.GetDiamondDetailAsync(diamondId);
            if (DiamondDetail == null)
            {
                return NotFound();
            }

            DiamondId = diamondId;
            TicketId = ticketId;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            DiamondDetail = await _diamondDetailService.GetDiamondDetailAsync(DiamondId);
            
            accId = HttpContext.Session.GetString("AccountId");
            Paper.Id = new Guid();
            Paper.TicketId = TicketId;
            Paper.IsDelete = false;
            Paper.StaffId = Guid.Parse(accId);
            Paper.Origin = DiamondDetail.Origin;
            Paper.CaratWeight = DiamondDetail.CaratWeight;
            Paper.Clarity = DiamondDetail.Clarity;
            Paper.Cut = DiamondDetail.Cut;
            Paper.Proportions = DiamondDetail.Proportions;
            Paper.Color = DiamondDetail.Color;
            Paper.Polish = DiamondDetail.Polish;
            Paper.Symmetry = DiamondDetail.Symmetry;
            Paper.Fluorescence = DiamondDetail.Fluorescence;
            
            await _assessmentPaperService.Create(Paper);

            return RedirectToPage("/Staff/AssessmentPaper/Index");

        }
    }
}