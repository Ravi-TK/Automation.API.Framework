using Automation.Framework.Core;

namespace Automation.API.Framework.BackEnd
{
    public class BaseURLs
    {
        public static string URL = "";
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
    }
}
