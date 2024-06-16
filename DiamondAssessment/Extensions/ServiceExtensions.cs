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
        services.AddScoped<IRegisterFormService, RegisterFormServices>();
        services.AddScoped<IStaffService, StaffServices>();
    }
    
    //public static void ConfigureServiceManager(this IServiceCollection services) =>
    //    services.AddScoped<IServiceManager, ServiceManager>();

    
    
}
