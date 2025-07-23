using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            // Register MediatR, validators, etc.
            return services;
        }
    }
}