using Microsoft.Extensions.DependencyInjection;
using ShortLi.Application.Services;
using ShortLi.Application.Services.Authentication;
namespace ShortLi.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection  services)
    {
        services.AddScoped<IAuthService, AuthenticationService>();
        
        return services;
    }
}