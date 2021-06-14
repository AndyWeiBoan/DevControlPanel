using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevControlPanel.Common.Repositories
{
    public static class LitedbProvider
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath = null)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();
            services.Configure<LiteDbConfig>(options => options.DatabasePath = databasePath);
        }
    }
}
