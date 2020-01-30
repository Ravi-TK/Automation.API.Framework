using Automation.API.Framework.Models.RequestModel;
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
        public static void createCustomer(string fname, string lname, int dob)
        {
            string queryBody;

            Customer cus = new Customer();

            cus.fname = fname;
            cus.lname = lname;
            cus.dob = dob;

            queryBody = SimpleJson.SerializeObject(cus);

            _commonPage.APIResponse = CommonAPICall.APICall(Method.POST,"/createcustomer",queryBody);
        }
    }
}
