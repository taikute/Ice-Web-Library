using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Models;

namespace WEB.Controllers
{
    public class BookController : Controller
    {
        readonly RestClient client;
        RestRequest? request;
        public BookController()
        {
            client = new RestClient("https://localhost:7042/api/books");
            request = null;
        }
        public IActionResult Index()
        {
            request = new RestRequest("", Method.Get);
            RestResponse<List<BookViewModel>> response = client.Execute<List<BookViewModel>>(request);
            List<BookViewModel>? books = response.Data;

            return View(books);
        }

        public IActionResult Edit(int id)
        {
            request = new RestRequest(id.ToString(), Method.Get);
            RestResponse<BookViewModel> response = client.Execute<BookViewModel>(request);
            var book = response.Data;
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(BookViewModel book)
        {
            request = new RestRequest($"{book.ID}", Method.Put);
            request.AddJsonBody(book);
            RestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update book";
                return View(book);
            }
        }
    }
}
