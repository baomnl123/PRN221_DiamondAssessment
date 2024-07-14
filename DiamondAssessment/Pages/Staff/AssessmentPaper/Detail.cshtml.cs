using IronPdf.Razor.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper
{
    public class Detail : PageModel
    {
        private readonly IAssessmentPaperService _assessmentPaperService;
        private readonly ISealingReportService _sealingReportService;
        private readonly ICommitmentFormService _commitmentFormService;

        public Detail(IAssessmentPaperService assessmentPaperService, ISealingReportService sealingReportService , ICommitmentFormService commitmentFormService)
        {
            _assessmentPaperService = assessmentPaperService;
            _sealingReportService = sealingReportService;
            _commitmentFormService = commitmentFormService;
        }
        
        [BindProperty]
        public Entities.Models.AssessmentPaper Paper { get; private set; }
        
        [BindProperty]
        public Guid? SealingReportId { get; private set; }
        public Guid? CommitmentId { get; private set; }
        public async Task<IActionResult> OnGet(Guid ticketId)
        {
            var paper = _assessmentPaperService
                .FindByCondition(p => p.TicketId == ticketId, false)
                .Include(p => p.Staff)
                .Include(p => p.Ticket)
                .FirstOrDefault();
            if (paper == null)
            {
                return NotFound();
            }

            Paper = paper;

            // Fetch the sealing report ID
            SealingReportId = await _sealingReportService.GetSealingReportIdByPaperIdAsync(Paper.Id);
            CommitmentId = await _commitmentFormService.GetCommitFormIdByPaperIdAsync(Paper.Id);
            return Page();
        }

        public async Task<IActionResult> OnPost(Guid ticketId)
        {
            // ChromePdfRenderer renderer = new ChromePdfRenderer();
            // PdfDocument pdf = renderer.RenderRazorToPdf(this);
            // Response.Headers.Append("Content-Disposition", "inline");
            // return File(pdf.BinaryData, "application/pdf", "razorPageToPdf.pdf");
            var renderer = new ChromePdfRenderer();
            var pdf = await renderer.RenderUrlAsPdfAsync($"http://localhost:5241/Staff/AssessmentPaper/Print/{ticketId}");
            return File(pdf.BinaryData, "application/pdf", "AssessmentPaper.pdf");
        }
    }
}
