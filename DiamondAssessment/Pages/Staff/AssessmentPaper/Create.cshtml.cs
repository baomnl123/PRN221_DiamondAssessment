using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;
using System;
using System.Threading.Tasks;
using Entities.Models.Enum;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper
{
    public class Create : PageModel
    {
        private readonly IAssessmentPaperService _assessmentPaperService;
        private readonly IDiamondDetailService _diamondDetailService;
        private readonly ITicketService _ticketService;
        private readonly IEmailService _emailService;

        public Create(IAssessmentPaperService assessmentPaperService, IDiamondDetailService diamondDetailService,
            ITicketService ticketService, IEmailService emailService)
        {
            _assessmentPaperService = assessmentPaperService;
            _diamondDetailService = diamondDetailService;
            _ticketService = ticketService;
            _emailService = emailService;
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
            Paper.CreatedAt = DateTime.UtcNow; // Assuming CreatedAt is set here
            await _assessmentPaperService.Create(Paper);

            var ticket = _ticketService
                .FindByCondition(d => d.Id == Paper.TicketId, false)
                .FirstOrDefault();
            if (ticket != null)
            {
                ticket.TicketStatus = TicketStatus.Done;
                await _ticketService.Update(ticket);
                
                var comeToStoreDate = Paper.CreatedAt.AddDays(7).ToString("dddd, MMMM dd, yyyy");

                var receiver = ticket.Email;
                var subject = "[PPBQ] Ticket Completion Notification";
                var message = $"Dear {ticket.TicketName},<br><br>" +
                              $"The assessment paper for your ticket has been successfully created and processed. " +
                              $"Please come to the store to retrieve your diamond and assessment paper before {comeToStoreDate}.<br><br>" +
                              $"If you do not arrive by then, we will seal your assessment paper.<br><br>" +
                              $"Thank you,<br>PPBQ";
                await _emailService.SendEmailAsync(receiver, subject, message);
            }

            return RedirectToPage("/Staff/AssessmentPaper/Index");

        }
    }
}