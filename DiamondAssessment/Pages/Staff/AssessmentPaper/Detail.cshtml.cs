using IronPdf.Razor.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;

namespace DiamondAssessment.Pages.Staff.AssessmentPaper;

public class Detail : PageModel
{
    private readonly IAssessmentPaperService _assessmentPaperService;
    private readonly ICompositeViewEngine _viewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;

    public Detail(IAssessmentPaperService assessmentPaperService, ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
    {
        _assessmentPaperService = assessmentPaperService;
        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
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

    public async Task<IActionResult> OnPost()
    {
        ChromePdfRenderer renderer = new ChromePdfRenderer();
        // Render Razor Page to PDF document
        PdfDocument pdf = renderer.RenderRazorToPdf(this);
        Response.Headers.Add("Content-Disposition", "inline");
        return File(pdf.BinaryData, "application/pdf", "razorPageToPdf.pdf");
    }

    // private async Task<string> RenderRazorViewToStringAsync(string viewName, object model)
    // {
    //     ViewData.Model = model;
    //
    //     using (StringWriter sw = new StringWriter())
    //     {
    //         var viewResult = _viewEngine.GetView("", viewName, false);
    //
    //         if (viewResult.View == null)
    //         {
    //             throw new ArgumentNullException($"{viewName} does not match any available view");
    //         }
    //
    //         var viewContext = new ViewContext(
    //             PageContext,
    //             viewResult.View,
    //             ViewData,
    //             TempData,
    //             sw,
    //             new HtmlHelperOptions()
    //         );
    //
    //         await viewResult.View.RenderAsync(viewContext);
    //
    //         return sw.ToString();
    //     }
    // }
}