using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiamondAssessment.Pages;

public class Login : PageModel
{
    [BindProperty]
    public string Username { get; set; }
    
    [BindProperty]
    public string Password { get; set; }

    public void OnPost()
    {
        try
        {
            //var loginAccount = _systemAccountService.Login(Username, Password);
            var loginAccount = new
            {
                AccountId = 1,
                AccountEmail = "mail@mail.com",
                AccountRole = 1
            };
            System.Diagnostics.Debug.WriteLine(loginAccount);
            HttpContext.Session.SetString("AccountId", loginAccount.AccountId.ToString());
            HttpContext.Session.SetString("AccountEmail", loginAccount.AccountEmail!);
            HttpContext.Session.SetString("Role", loginAccount.AccountRole.ToString()!);
            switch (loginAccount.AccountRole)
            {
                case 1:
                    Response.Redirect("/Staff/RegisterForm/FormPage");
                    break;
                case 2:
                    Response.Redirect("/Admin/Account/Index");
                    break;
            }
        }
        catch (Exception e)
        {
            if (e.Message.Contains("Username or password"))
                ModelState.AddModelError("LoginFailed", e.Message);
            else
                ModelState.AddModelError("LoginFailed", "An error occurred while logging in");
        }
    }
}