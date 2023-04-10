using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
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
            var response = client.Execute<List<T>>(new RestRequest(endpoint));
            if (response.IsSuccessful)
            {
                var data = response.Data;
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(data)}");
                return data;
            }
            else
            {
                Console.WriteLine("ERROR!!!");
                return null;
            }
        } 
        //GetByID
        public static T? GetByID<T>(int id, string endpoint)
        {
            return client.Execute<T>(new RestRequest($"{endpoint}/{id}")).Data;
        }
    }
}
