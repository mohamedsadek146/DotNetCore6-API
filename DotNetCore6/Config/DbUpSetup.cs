using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetCore6.API.Config
{
    public static class DbUpSetup
    {
        public static void AddDbUp(this IServiceCollection services, IConfiguration Configuration)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                   .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    // .WithScriptsFromFileSystem(@"") 
                    .Build();
            var result = upgrader.PerformUpgrade();
        }
    }
}
