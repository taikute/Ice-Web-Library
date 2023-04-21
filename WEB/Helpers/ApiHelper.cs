using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WEB.Helpers
{
    public class ApiHelper
    {
        readonly RestClient client = new RestClient("https://localhost:7042/api/");
        //GetList
        public async Task<IEnumerable<T>>? GetAll<T>(string endpoint) where T : class
        {
            var response = await client.ExecuteAsync<List<T>>(new RestRequest(endpoint));
            return response.Data!;
        }
        //GetByID
        public async Task<T>? GetByID<T>(int id, string endpoint) where T : class
        {
            var response = await client.ExecuteAsync<T>(new RestRequest($"{endpoint}/{id}"));
            return response.Data!;
        }
        public async Task Post<T>(T data, string endpoint) where T : class
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddJsonBody(data);
            try
            {
                await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task Put<T>(T data, string endpoint) where T : class
        {
            var request = new RestRequest($"{endpoint}", Method.Put);
            request.AddJsonBody(data);
            try
            {
                await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task Delete<T>(int id, string endpoint) where T : class
        {
            var request = new RestRequest($"{endpoint}/{id}", Method.Delete);
            try
            {
                await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
