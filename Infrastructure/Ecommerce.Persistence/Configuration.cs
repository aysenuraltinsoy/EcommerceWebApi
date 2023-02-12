using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence
{
    static class Configuration
    {

        static public string ConnectionString
        {
            get
            {
                // Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json nuget packages installed for this section
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Ecommerce.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("ConnString");
            }
        }
    }
}
