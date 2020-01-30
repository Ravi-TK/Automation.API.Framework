using RestSharp;

namespace Automation.API.Framework.BackEnd
{
    public class CommonAPICall
    {
        /// <summary>
        /// Executes the REST request
        /// </summary>
        /// <param name="method"> REST Call Type</param>
        public static IRestResponse APICall(Method method, string endPoint, string queryBody = "", bool hasPermission = true)
        {
            IRestClient client = new RestClient();
            IRestRequest request = new RestRequest(BaseURLs.URL + endPoint, Method.GET);

            //adding bearer token
            // request.AddHeader("Authorization", "");

            //adding queryBody
            if (!string.IsNullOrEmpty(queryBody))
                request.AddParameter("undefined", queryBody, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}