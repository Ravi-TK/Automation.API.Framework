using RestSharp;

namespace Automation.API.Framework.BackEnd
{
    public class CommonPage
    {
        public IRestResponse APIResponse;
        private string _token;

        /// <summary>
        /// Bearer token to access the resource
        /// </summary>
        public string bearerToken
        {
            get { return _token; }
            set { _token = value; }
        }

        /// <summary>
        /// Returns a new token
        /// </summary>
        /// <returns>Returns a new token</returns>
        public string GetBearerToken()
        {
            _token = GenerateBearerToken();
            return _token;
        }

        /// <summary>
        /// Generates a new token
        /// </summary>
        /// <returns></returns>
        private string GenerateBearerToken()
        {
            //code to go here to generate bearer token
            return "";
        }
    }
}