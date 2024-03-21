using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KinderConnect.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The assembly is taken from the type of random service implementation provided.
        /// </summary>
        /// <param name="serviceType">Type of random service should be provided</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] servicesTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type implementationType in servicesTypes)
            {
                Type? interfaceType =
                    implementationType.GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException(
                        $"No interface is provided for the service with name {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }

            services.AddScoped<ITeacherService, TeacherService>();
        }
    }
}
