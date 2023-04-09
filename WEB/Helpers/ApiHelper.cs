using RestSharp;

namespace WEB.Helpers
{
    public static class ApiHelper
    {
        public static readonly RestClient client = new RestClient("https://localhost:7042/api/");
        public static RestRequest? request = null;
        //GetList
        public static List<T>? GetList<T>(string endpoint)
        {
            return client.Execute<List<T>>(new RestRequest(endpoint)).Data;
        }
        //GetByID
        public static T? GetByID<T>(int id, string endpoint)
        {
            return client.Execute<T>(new RestRequest($"{endpoint}/{id}")).Data;
        }
    }
}
