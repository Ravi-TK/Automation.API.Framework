using Automation.Framework.Base;
using RestSharp;
using System;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Create
{
    class CreateCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static void createCustomer(string fname, string lname, string dob)
        {
            string queryBody = "{\r\n  ";

            if (!string.IsNullOrEmpty(fname))
                queryBody += "\"FirstName\": \"" + fname + "\",\r\n";
            if (!string.IsNullOrEmpty(lname))
                queryBody += "  \"LastName\": \"" + lname + "\",\r\n  ";
            if (!string.IsNullOrEmpty(dob))
                queryBody += "\"DateOfBirth\": \"" + dob + "\"";

            queryBody += "\r\n}";

            _commonPage.APIResponse = CommonAPICall.APICall(Method.POST,"/createcustomer",queryBody);
        }
    }
}
