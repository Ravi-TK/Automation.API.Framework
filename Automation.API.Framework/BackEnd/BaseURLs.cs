using Automation.Framework.Core;

namespace Automation.API.Framework.BackEnd
{
    public class BaseURLs
    {
        public static string URL = "",tokenURL="";
        internal static void SetBaseUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            if (testEnvironment == Envirnoment.SysTest)
            {
                URL = "";
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                URL = "";
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                URL = "";
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                URL = "";
            }
        }

        internal static void SetTokenUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            if (testEnvironment == Envirnoment.SysTest)
            {
                tokenURL = "";
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                tokenURL = "http://wcs-d-web01:44379/api/values";
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                tokenURL = "";
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                tokenURL = "";
            }
        }
    }
}
