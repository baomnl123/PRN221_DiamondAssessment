using Service.Abstractions;
using Service.Services;

namespace DiamondAssessment.Extensions;

public static class ServiceExtensions
{
    //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
    //    services.AddScoped<IRepositoryManager, RepositoryManager>();


    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentPaperService, AssessmentPaperServices>();
        services.AddScoped<IDiamondDetailService, DiamondDetailService>();
        services.AddScoped<IRegisterFormService, RegisterFormServices>();
        services.AddScoped<IStaffService, StaffServices>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ISealingReportService, SealingReportServices>();
        services.AddScoped<ICommitmentFormService, CommitmentFormServices>();
        services.AddScoped<IEmailService, EmailService>();
    }

    //public static void ConfigureServiceManager(this IServiceCollection services) =>
    //    services.AddScoped<IServiceManager, ServiceManager>();
}
