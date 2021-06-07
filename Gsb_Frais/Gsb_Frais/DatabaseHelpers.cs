using Microsoft.Extensions.Configuration;
using System.IO;

namespace Gsb_Frais
{
    public static class DatabaseHelpers
    {
        static IConfiguration _configuration;

        public static string ConnectionString
        {
            get
            {
                return Configuration["Connectionstrings:Gb_Frais"];
            }
        }


        static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddEnvironmentVariables()
                        .Build();
                }

                return _configuration;
            }
        }
    }
}
