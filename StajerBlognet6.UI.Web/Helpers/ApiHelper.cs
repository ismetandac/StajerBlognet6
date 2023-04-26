using Newtonsoft.Json;
using RestSharp;

namespace StajerBlognet6.UI.Web.Helpers
{
    public static class ApiHelper
    {
        static string BaseUrl = "https://localhost:7084/";

        static RestClient Client;
        static ApiHelper()
        {
            Client = new RestClient(BaseUrl);
        }

        public static T Post<T>(string url, object entity)
            where T : class, new()
        {
            var request = new RestRequest(url, Method.Post);
            request.AddJsonBody(entity);
            var response = Client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<T>(response.Content);
                return data;
            }
            return null;
        }

        public static void Get()
        {

        }
    }
}
