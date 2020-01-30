using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Retrieve
{
    public class GetCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static void getCustomer(int cusID)
        {
            _commonPage.APIResponse = CommonAPICall.APICall(Method.GET, "/customer/" + cusID);
        }
    }
}