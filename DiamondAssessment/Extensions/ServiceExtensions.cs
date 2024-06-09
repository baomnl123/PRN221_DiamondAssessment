using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Repository.Abstractions;
using Repository.Repositories;
using Service.Services;


namespace DiamondAssessment.Extensions;

public static class ServiceExtensions
{
    //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
    //    services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void ConfigureDaos(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentPaperDao, AssessmentPaperDao>();

    }
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentPaperRepository, AssessmentPaperRepository>();

    }
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<AssessmentPaperServices>();

    }
    
    //public static void ConfigureServiceManager(this IServiceCollection services) =>
    //    services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("DiamondAssessment"))
        );
    
}
