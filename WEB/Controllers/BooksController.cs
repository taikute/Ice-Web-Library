using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Models;
using WEB.Helpers;
using System.Net;

namespace WEB.Controllers
{
    public class BooksController : Controller
    {
        readonly ApiHelper _apiHelper;
        public BooksController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _apiHelper.GetAll<Book>("Books")!;
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Manager()
        {
            var books = await _apiHelper.GetAll<Book>("Books")!;

            foreach (var book in books)
            {
                book.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors")!;
                book.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories")!;
                book.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers")!;
            }
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors")!;
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories")!;
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers")!;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            book.BookId = 0;
            if (ModelState.IsValid)
            {
                await _apiHelper.Post(book, "Books");
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessenger = "Thông tin nhập không hợp lệ!";
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            book.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors")!;
            book.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories")!;
            book.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers")!;
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors")!;
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories")!;
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers")!;
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _apiHelper.Put(book, "Books");
                return RedirectToAction("Detail", new { id = book.BookId });
            }
            return View(book);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiHelper.Delete<Book>(id, "Books");
            return RedirectToAction("Manager");
        }
    }
}
