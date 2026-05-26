using LibraryManagement.Application.Extensions;
using LibraryManagement.Infrastructure.Extensions;

namespace LibraryManagementApi.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddLibraryManagementServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices(configuration);
        return services;
    }
}
