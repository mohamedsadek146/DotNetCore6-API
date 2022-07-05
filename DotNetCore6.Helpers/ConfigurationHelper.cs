using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DotNetCore6.Helpers
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //if (string.IsNullOrEmpty(environment))
            //    environment = "Production";
            //var configurationBuilder = new ConfigurationBuilder();
            //var path = Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.{environment}.json");
            //configurationBuilder.AddJsonFile(path, false);
            //var root = configurationBuilder.Build();
            //var dd = root.GetSection("ConnectionStrings");
            //string _connectionString = root.GetSection("ConnectionStrings:Default").Value;
            //return _connectionString;
            return "";
        }

    }
}
