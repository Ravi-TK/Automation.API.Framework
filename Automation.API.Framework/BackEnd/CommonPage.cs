using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.API.Framework.BackEnd
{
    public class CommonPage
    {
        IRestResponse APIResponse;
        string token;

        public static string GetBearerToken()
        {
            string token="";

            return token;
        }


    }
}
