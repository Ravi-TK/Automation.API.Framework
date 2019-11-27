using Automation.Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.API.Framework.BackEnd
{
    public class DBConnectionStrings
    {
        public static string DBConnectionStr = "";

        internal static void SetDBConnectionString(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            if (testEnvironment == Envirnoment.SysTest) DBConnectionStr = "Server=wcs-t-sssql1,65001; Database=WescotIncomeExpenditure; Trusted_Connection=True; MultipleActiveResultSets=True;Integrated Security=true;";
            else if (testEnvironment == Envirnoment.Dev) DBConnectionStr = "Server=wcs-d-sssql1,65001; Database=WescotIncomeExpenditure; Trusted_Connection=True; MultipleActiveResultSets=True;Integrated Security=true;";
            else if (testEnvironment == Envirnoment.UAT) DBConnectionStr = "";
            else if (testEnvironment == Envirnoment.Staging) DBConnectionStr = "";
            else if (testEnvironment == Envirnoment.Live) DBConnectionStr = "";
        }
    }
}
