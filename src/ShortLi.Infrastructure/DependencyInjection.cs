using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortLi.Infrastructure.Authentication;
using ShortLi.Infrastructure.Authentication.JWT;

namespace ShortLi.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructre(this IServiceCollection  services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJWTToken, JwtToken>();

        return services;
    }
}