using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WEB.Helpers
{
    public class ApiHelper
    {
        readonly RestClient client = new RestClient("https://localhost:7042/api/");
        //GetList
        public async Task<List<T>>? GetList<T>(string endpoint)
        {
            var response = await client.ExecuteAsync<List<T>>(new RestRequest(endpoint));
            if (!response.IsSuccessful)
            {
                throw new Exception("Fail!");
            }
            return response.Data!;
        }
        //GetByID
        public async Task<T>? GetByID<T>(int id, string endpoint)
        {
            var response = await client.ExecuteAsync<T>(new RestRequest($"{endpoint}/{id}"));
            return response.Data!;
        }
        public async Task Put<T>(T data, string endpoint) where T : class
        {
            var request = new RestRequest($"{endpoint}", Method.Put);
            request.AddJsonBody(data);
            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception("Fail!");
            }
            return;
        }
    }
}
