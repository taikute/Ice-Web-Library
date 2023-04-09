using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Models;
using WEB.Helpers;

namespace WEB.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = ApiHelper.GetList<BookVM>("Books");
            if (books != null)
            {
                foreach (var book in books)
                {
                    var author = ApiHelper.GetByID<AuthorVM>(book.AuthorID, "BookAuthors");
                    if (author != null) book.AuthorName = author.Name ?? "Unknow";
                    else return NotFound("Author");

                    var category = ApiHelper.GetByID<CategoryVM>(book.CategoryID, "BookCategories");
                    if (category != null) book.CategoryName = category.Name ?? "Unknow";
                    else return NotFound("Category");
                }
            }
            else return BadRequest();
            return View(books);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = ApiHelper.GetByID<BookVM>(id, "Books");
            if (book == null) return NotFound();
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int id, BookVM book)
        {
            ApiHelper.request = new RestRequest($"books/{id}", Method.Put);
            ApiHelper.request.AddJsonBody(book);
            RestResponse response = ApiHelper.client.Execute(ApiHelper.request);
            if (response.IsSuccessful) return RedirectToAction("Index");
            else
            {
                TempData["ErrorMessage"] = "Failed to update book";
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var book = ApiHelper.GetByID<BookVM>(id, "books");

            return View(book);
        }
    }
}
