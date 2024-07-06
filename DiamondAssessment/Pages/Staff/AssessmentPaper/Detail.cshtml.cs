using IronPdf.Razor.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper;

public class Detail : PageModel
{
    private readonly IAssessmentPaperService _assessmentPaperService;

    public Detail(IAssessmentPaperService assessmentPaperService)
    {
        _assessmentPaperService = assessmentPaperService;
    }
    
    [BindProperty]
    public Entities.Models.AssessmentPaper Paper { get; private set; }

    public IActionResult OnGet(Guid id)
    {
        var paper = _assessmentPaperService
            .FindByCondition(p => p.Id == id, false)
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

    public IActionResult OnPost()
    {
        ChromePdfRenderer renderer = new ChromePdfRenderer();
        // Render Razor Page to PDF document
        PdfDocument pdf = renderer.RenderRazorToPdf(this);
        Response.Headers.Add("Content-Disposition", "inline");
        return File(pdf.BinaryData, "application/pdf", "razorPageToPdf.pdf");
    }
}