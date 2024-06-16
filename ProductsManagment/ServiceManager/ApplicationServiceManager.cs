
using ProductsManagment.Common.Common;
using ProductsManagment.DAL;

namespace ProductsManagment.ServiceManager
{
    public static class ApplicationServiceManager
    {
        public static IServiceCollection AddProviderSettings( this IServiceCollection services, IConfiguration configuration)
        {
            //Api Settings 
            var api_section = configuration.GetSection($"DatabaseSettings");

            var _providerSettingsConfig = api_section.Get<DBSettings>();

            services.AddSingleton<DBSettings>(_providerSettingsConfig);

            Mappings.RegisterClassMaps();

            return services;
        }

    }
}
