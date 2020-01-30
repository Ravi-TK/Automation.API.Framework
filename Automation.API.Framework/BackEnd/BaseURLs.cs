using Automation.Framework.Core;
using Microsoft.Extensions.Configuration;

namespace Automation.API.Framework.BackEnd
{
    public class BaseURLs
    {
        public static string URL = "", tokenURL = "";

        internal static void SetBaseUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            var config = new ConfigurationBuilder()
                             .AddJsonFile("AppConfig.json")
                             .Build();

            if (testEnvironment == Envirnoment.SysTest)
            {
                URL = config["baseURLSysTest"];
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                URL = config["baseURLDev"];
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                URL = config["baseURLUAT"];
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                URL = config["baseURLPreStaging"];
            }
        }

        internal static void SetTokenUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            var config = new ConfigurationBuilder()
                             .AddJsonFile("AppConfig.json")
                             .Build();

            if (testEnvironment == Envirnoment.SysTest)
            {
                tokenURL = config["tokenURLSysTest"];
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                tokenURL = config["tokenURLDev"];
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                tokenURL = config["tokenURLUAT"];
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                tokenURL = config["tokenURLPreStaging"];
            }
        }
    }
}