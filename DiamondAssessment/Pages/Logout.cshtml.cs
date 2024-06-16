using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondAssessment.Pages;

public class Logout : PageModel
{
    public void OnPost()
    {
        HttpContext.Session.Clear();
        Response.Redirect("/Login");
    }
}