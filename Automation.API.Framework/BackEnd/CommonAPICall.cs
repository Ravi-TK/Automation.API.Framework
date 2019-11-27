using Automation.Framework.Core;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.API.Framework.BackEnd
{
    public class CommonAPICall
    {
        public static void APICall(Method method)
        {
            IRestClient client = new RestClient();
            // IRestRequest request = new RestRequest(BaseURLs.URL, method);

            IRestRequest request = new RestRequest("http://wcs-d-web01:44379/api/values", Method.GET);
           // client.Authenticator = new SimpleAuthenticator("username", "SVC_D_AFS_SERVICE", "password", "ZEX317jlk953");
            client.Authenticator=new NtlmAuthenticator("SVC_D_AFS_SERVICE", "ZEX317jlk953");

           // request.Credentials
           // request.AddHeader("Authorization", "NTLM TlRMTVNTUAADAAAAGAAYAGoAAAAYABgAggAAAAAAAABIAAAAIgAiAEgAAAAAAAAAagAAAAAAAACaAAAABYKIogUBKAoAAAAPUwBWAEMAXwBEAF8AQQBGAFMAXwBTAEUAUgBWAEkAQwBFAEuMI/xeqYQwAAAAAAAAAAAAAAAAAAAAALvDrm70BEDj/Omt4tJZ2LBlulwQBUfaSg==");

            IRestResponse response = client.Execute(request);

            Console.WriteLine((int)response.StatusCode);
            int statusCode = (int)response.StatusCode;
            Console.WriteLine(response.Content);

        }
    }
}
