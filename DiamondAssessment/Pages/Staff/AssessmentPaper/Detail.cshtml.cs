using IronPdf.Razor.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper
{
    public class Detail : PageModel
    {
        private readonly IAssessmentPaperService _assessmentPaperService;

        public Detail(IAssessmentPaperService assessmentPaperService)
        {
            _assessmentPaperService = assessmentPaperService;
        }
        
        [BindProperty]
        public Entities.Models.AssessmentPaper Paper { get; private set; }

        public IActionResult OnGet(Guid ticketId)
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
            return File(pdf.BinaryData, "application/pdf", "razorPageToPdf.pdf");
        }
    }
}
