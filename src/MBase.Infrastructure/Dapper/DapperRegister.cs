using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MBase.Infrastructure.Dapper
{
    public static class DapperRegister
    {
        public static void UseDapper(this IServiceCollection services)
        {
            var baseType = typeof(IDapperService);

            var assembly = Assembly.GetEntryAssembly();

            if (assembly == null)
                assembly = Assembly.GetCallingAssembly();

            var types = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false } && baseType.IsAssignableFrom(t));

            foreach (var derivedType in types)
            {
                var interfaceType = derivedType
                    .GetInterfaces()
                    .FirstOrDefault(i => i != typeof(IDapperService) && baseType.IsAssignableFrom(i));

                if (interfaceType != null)
                    services.AddScoped(interfaceType, derivedType);
            }
        }
    }
}
