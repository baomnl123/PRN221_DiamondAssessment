using Service.Abstractions;
using Service.Services;
using Service.Abstractions;


namespace DiamondAssessment.Extensions;

public static class ServiceExtensions
{
    //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
    //    services.AddScoped<IRepositoryManager, RepositoryManager>();
    
    
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentPaperService, AssessmentPaperServices>();

    }
    
    //public static void ConfigureServiceManager(this IServiceCollection services) =>
    //    services.AddScoped<IServiceManager, ServiceManager>();

    
    
}
