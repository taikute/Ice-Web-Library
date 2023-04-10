using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Models;
using WEB.Helpers;
using WEB.Models.BookModels;

namespace WEB.Controllers
{
    public class BookController : Controller
    {
        /*        List<BookVM> books = ApiHelper.GetList<BookVM>("Books")!;
                public BookController()
                {
                    //UpdateData
                    foreach (var book in books)
                    {
                        var author = ApiHelper.GetByID<AuthorVM>(book.AuthorID, "BookAuthors")!;
                        book.AuthorName = author.Name!;

                        var category = ApiHelper.GetByID<CategoryVM>(book.CategoryID, "BookCategories")!;
                        book.CategoryName = category.Name!;
                    }
                }*/
        public IActionResult Index()
        {
            var books = ApiHelper.GetList<BookIndexVM>("Books");
            if (books == null)
            {
                return BadRequest("Book Null On Web/Book/Index");
            }
            return View(books);
        }

        /*        [HttpGet]
                public IActionResult Delete(int id)
                {
                    var book = books.FirstOrDefault(x => x.ID == id);
                    return View(book);
                }
                [HttpPost]
                public IActionResult Delete(int id, BookVM book)
                {
                    ApiHelper.request = new RestRequest($"books/{id}", Method.Delete);
                    RestResponse response = ApiHelper.client.Execute(ApiHelper.request);
                    if (response.IsSuccessful) return RedirectToAction("Index");
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to delete book";
                        return View(book);
                    }
                }

                [HttpGet]
                public IActionResult Edit(int id)
                {
                    var book = books.FirstOrDefault(x => x.ID == id);
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
                    var book = books.FirstOrDefault(x => x.ID == id);
                    return View(book);
                }*/
    }
}
