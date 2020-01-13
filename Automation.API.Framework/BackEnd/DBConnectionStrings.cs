using Automation.Framework.Core;
using Microsoft.Extensions.Configuration;

namespace Automation.API.Framework.BackEnd
{
    public class DBConnectionStrings
    {
        public static string DBConnectionStr = "";

        /// <summary>
        /// Sets the database connection to the chosen environment 
        /// </summary>
        /// <param name="testEnvironment"></param>
        internal static void SetDBConnectionString(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            var config = new ConfigurationBuilder()
                          .AddJsonFile("AppConfig.json")
                          .Build();

            if (testEnvironment == Envirnoment.SysTest) DBConnectionStr = config["SysTestDB"];
            else if (testEnvironment == Envirnoment.Dev) DBConnectionStr = config["DevDB"];
            else if (testEnvironment == Envirnoment.UAT) DBConnectionStr = config["UATDB"];
            else if (testEnvironment == Envirnoment.Staging) DBConnectionStr = config["PreStagingDB"];
            //else if (testEnvironment == Envirnoment.Live) DBConnectionStr = config[""];
        }
    }
}
