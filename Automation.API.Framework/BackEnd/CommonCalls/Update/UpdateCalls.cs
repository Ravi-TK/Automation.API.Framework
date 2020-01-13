using Automation.Framework.Base;
using RestSharp;
using Unity;


namespace Automation.API.Framework.BackEnd.CommonCalls.Update
{
    public class UpdateCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static void UpdateCustomer(string cusId, string fname, string lname,string DateOfBirth)
        {
            string queryBody = "{\r\n  ";

            if (!string.IsNullOrEmpty(fname))
                queryBody += "\"FirstName\": \"" + fname + "\",\r\n";
            if (!string.IsNullOrEmpty(lname))
                queryBody += "  \"LastName\": \"" + lname + "\",\r\n  ";
            if (!string.IsNullOrEmpty(DateOfBirth))
                queryBody += "\"DateOfBirth\": \"" + DateOfBirth + "\"";

            queryBody += "\r\n}";

            _commonPage.APIResponse = CommonAPICall.APICall(Method.PUT, "/customer/" + cusId, queryBody);
        }
    }
}
