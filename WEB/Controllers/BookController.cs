using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Models;

namespace WEB.Controllers
{
    public class BookController : Controller
    {

        public IActionResult Index()
        {
            var client = new RestClient("https://localhost:7042/api/");
            var request = new RestRequest("books", Method.Get);
            RestResponse<List<BookViewModel>> response = client.Execute<List<BookViewModel>>(request);
            List<BookViewModel>? books = response.Data;

            return View(books);
        }

    }
}
