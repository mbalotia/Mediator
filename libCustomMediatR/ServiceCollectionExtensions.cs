using Microsoft.Extensions.DependencyInjection;

namespace libCustomMediatR;


public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers handlers and mediator types from the specified assemblies
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">The action used to configure the options</param>
    /// <returns>Service collection</returns>
    public static IServiceCollection AddMediator(this IServiceCollection services, Action<MediatRServiceConfiguration> configuration)
    {
        var serviceConfig = new MediatRServiceConfiguration();

        configuration.Invoke(serviceConfig);

        if (!serviceConfig.AssembliesToRegister.Any())
        {
            throw new ArgumentException("No assemblies found.");
        }

        ServiceRegistrar.Register(services, serviceConfig);
        
        return services;
    }

}