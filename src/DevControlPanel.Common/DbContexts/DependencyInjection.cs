using Microsoft.Extensions.DependencyInjection;

namespace DevControlPanel.Common
{
    public static class DbContextDependencyInjection
    {
        public static void AddLiteDb(this IServiceCollection services)
        {
            services.AddSingleton<DbContext>();
        }
    }
}
