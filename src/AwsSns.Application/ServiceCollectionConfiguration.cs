using AwsSns.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AwsSns.Domain.Entities;
using AwsSns.Domain.Interfaces;
using IStatusService = AwsSns.Application.Interfaces.IStatusService;

namespace AwsSns.Application
{
    public static class ServiceCollectionConfiguration
    {
        /// <summary>
        /// Register all your interfaces and implementations here
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>A <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IEventPublisherService, EventPublisherService>();

            services.Configure<SNSSettings>(configuration.GetSection("EventPublishing"));

            return services;
        }
    }
}