using Microsoft.Extensions.DependencyInjection;
using ShortLi.Infrastructure.Authentication;

namespace ShortLi.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructre(this IServiceCollection  services)
    {
        services.AddScoped<IJWTToken, JwtToken>();

        return services;
    }
}