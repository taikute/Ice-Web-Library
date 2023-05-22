using RestSharp;

namespace WEB.Helpers
{
    public class ApiHelper
    {
        readonly RestClient localClient = new("https://localhost:7042/api/");

        //readonly RestClient gmailClient = new("https://gmail.googleapis.com");
        //public bool CheckEmailValidity(string emailAddress)
        //{
        //    var request = new RestRequest($"gmail/v1/users/{emailAddress}/profile", Method.Get);
        //    var response = gmailClient.Execute(request);
        //    return response.IsSuccessful;
        //}

        //GetList
        public async Task<IEnumerable<T>?> GetAll<T>(string endpoint) where T : class
        {
            var response = await localClient.ExecuteAsync<List<T>>(new RestRequest(endpoint));
            return response.Data;
        }
        //GetByID
        public async Task<T?> GetByID<T>(int id, string endpoint) where T : class
        {
            var response = await localClient.ExecuteAsync<T>(new RestRequest($"{endpoint}/{id}"));
            return response.Data;
        }
        public async Task Post<T>(T data, string endpoint) where T : class
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddJsonBody(data);
            try
            {
                await localClient.ExecuteAsync(request);
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
                await localClient.ExecuteAsync(request);
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
                await localClient.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<bool> IsResponse()
        {
            try
            {
                var response = await localClient.ExecuteAsync(new RestRequest("Books"));
                return response.IsSuccessful;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
