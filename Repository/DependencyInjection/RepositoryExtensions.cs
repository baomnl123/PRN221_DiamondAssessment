using Microsoft.Extensions.DependencyInjection;
using Repository.Abstractions;
using Repository.Repositories;

namespace Repository.DependencyInjection;

public static class RepositoryExtensions
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentPaperRepository, AssessmentPaperRepository>();
        services.AddScoped<IDiamondDetailRepository, DiamondDetailRepository>();
        services.AddScoped<IRegisterFormRepository, RegisterFormRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
    }
}
