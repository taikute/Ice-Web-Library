using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Models;
using WEB.Helpers;

namespace WEB.Controllers
{
    public class BookController : Controller
    {
        readonly ApiHelper _apiHelper;
        public BookController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _apiHelper.GetList<BookIndexModel>("Books/GetListBookIndex")!;
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _apiHelper.GetByID<BookModel>(id, "Books/GetBook")!;
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiHelper.GetByID<BookModel>(id, "Books/GetBook")!;
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                await _apiHelper.Put(book, $"Books");
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
