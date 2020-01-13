using Automation.Framework.Base;
using RestSharp;
using Unity;


namespace Automation.API.Framework.BackEnd.CommonCalls.Delete
{
    public class DeleteCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static void DeleteCustomer(string cusID)
        {
            _commonPage.APIResponse = CommonAPICall.APICall(Method.DELETE,"\\customer\\"+cusID+"\\delete");
        }
    }
}
