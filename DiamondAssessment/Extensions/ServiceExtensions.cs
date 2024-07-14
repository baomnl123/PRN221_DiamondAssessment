using System.Configuration;
using Entities.Models;
using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Extensions;

public static class ServiceExtensions
{
    //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
    //    services.AddScoped<IRepositoryManager, RepositoryManager>();


    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAssessmentPaperService, AssessmentPaperServices>();
        services.AddScoped<IDiamondDetailService, DiamondDetailService>();
        services.AddScoped<IRegisterFormService, RegisterFormServices>();
        services.AddScoped<IStaffService, StaffServices>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ISealingReportService, SealingReportServices>();
        services.AddScoped<ICommitmentFormService, CommitmentFormServices>();
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();
    }

    //public static void ConfigureServiceManager(this IServiceCollection services) =>
    //    services.AddScoped<IServiceManager, ServiceManager>();
}
