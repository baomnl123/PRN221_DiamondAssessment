using DataAccessLayer.Context;
using DataAccessLayer.Dao;
using DataAccessLayer.Dao.Abstractions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.DependencyInjection;

public static class DependencyInjection
{
    public static void ConfigureSqlContext(
        this IServiceCollection services,
        IConfiguration configuration
    ) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(
                configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("DiamondAssessment")
            )
        );

    public static void ConfigureDaos(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentPaperDao, AssessmentPaperDao>();
        services.AddScoped<IRegisterFormDao, RegisterFormDao>();
        services.AddScoped<IDiamondDetailDao, DiamondDetailDao>();
        services.AddScoped<IStaffDao, StaffDao>();
        services.AddScoped<ITicketDao, TicketDao>();
    }
}
