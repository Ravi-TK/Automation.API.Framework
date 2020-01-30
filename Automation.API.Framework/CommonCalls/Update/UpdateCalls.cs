using Automation.API.Framework.Models.RequestModel;
using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Update
{
    public class UpdateCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static void UpdateCustomer(int cusId, string fname, string lname, int DateOfBirth)
        {
            string queryBody;

            Customer cus = new Customer();

            cus.cusID = cusId;
            cus.fname = fname;
            cus.lname = lname;
            cus.dob = DateOfBirth;

            queryBody = SimpleJson.SerializeObject(cus);

            _commonPage.APIResponse = CommonAPICall.APICall(Method.PUT, "/customer/" + cusId, queryBody);
        }
    }
}