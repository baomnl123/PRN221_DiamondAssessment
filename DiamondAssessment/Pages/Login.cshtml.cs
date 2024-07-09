using Entities.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Abstractions;

namespace DiamondAssessment.Pages;

public class Login : PageModel
{
    private readonly IStaffService _staffService;

    public Login(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public void OnPost()
    {
        try
        {
            var loginAccount = _staffService
                .FindByCondition(
                    x => (x.Email == Email || x.PhoneNumber == Email) && x.Password == Password,
                    false
                )
                .FirstOrDefault();
            // var loginAccount = new
            // {
            //     AccountId = 1,
            //     AccountEmail = "mail@mail.com",
            //     AccountRole = 3
            // };
            // if (Username == "admin")
            // {
            //     loginAccount = new
            //     {
            //         AccountId = 1,
            //         AccountEmail = "mail@mail.com",
            //         AccountRole = 1
            //     };
            // }
            // else if (Username == "manager")
            // {
            //     loginAccount = new
            //     {
            //         AccountId = 1,
            //         AccountEmail = "mail@mail.com",
            //         AccountRole = 2
            //     };
            // }
            System.Diagnostics.Debug.WriteLine(loginAccount);
            // HttpContext.Session.SetString("AccountId", loginAccount.AccountId.ToString());
            // HttpContext.Session.SetString("AccountEmail", loginAccount.AccountEmail!);
            // HttpContext.Session.SetString("Role", loginAccount.AccountRole.ToString()!);
            HttpContext.Session.SetString("AccountId", loginAccount.Id.ToString());
            HttpContext.Session.SetString("AccountEmail", loginAccount.Email!);
            HttpContext.Session.SetString("Role", loginAccount.Role.ToString()!);
            switch (loginAccount.Role)
            {
                case Role.Admin:
                    Response.Redirect("/Admin/Account/Index");
                    break;
                case Role.Manager:
                    Response.Redirect("/Index");
                    break;
                case Role.Staff:
                    Response.Redirect("/Staff/RegisterForm/FormPage");
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
