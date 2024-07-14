using DataAccessLayer.Context;
using DataAccessLayer.DependencyInjection;
using DiamondAssessment.Extensions;
using Microsoft.EntityFrameworkCore;
using Repository.DependencyInjection;
using IronPdf;
var builder = WebApplication.CreateBuilder(args);

//Add key license of ironPdf
IronPdf.License.LicenseKey = "IRONSUITE.PHATNHSE171208.FPT.EDU.VN.32247-DDA402F330-DHOYZPC-6DXRQRDINH6F-CYYJMAO52ETO-EKEYOXGBET3B-PJYPULRO66CZ-HUVU2KRJFV7H-2SMPAV4LRY3Y-23G5W4-TYVBJ45FSHKNEA-DEPLOYMENT.TRIAL-A4ROGI.TRIAL.EXPIRES.05.AUG.2024";

// Add services to the container.
builder.Services.AddRazorPages();

// builder.Services.ConfigureRepositoryManager();
// builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureDaos();
builder.Services.ConfigureRepositories();

builder.Services.ConfigureServices(builder.Configuration); // Pass IConfiguration here

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
