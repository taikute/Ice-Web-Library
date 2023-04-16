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
            var books = await _apiHelper.GetList<BookIndexModel>("Books/GetListBookIndex")!;
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Manager()
        {
            var books = await _apiHelper.GetList<BookModel>("Books/GetListBook")!;
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _apiHelper.GetList<AuthorModel>("Authors")!;
            ViewBag.Categories = await _apiHelper.GetList<CategoryModel>("Categories")!;
            ViewBag.Publishers = await _apiHelper.GetList<PublisherModel>("Publishers")!;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookBaseModel book)
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
            var book = await _apiHelper.GetByID<BookModel>(id, "Books/GetBook")!;
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiHelper.GetByID<BookBaseModel>(id, "Books/GetBookBase")!;
            ViewBag.Authors = await _apiHelper.GetList<AuthorModel>("Authors")!;
            ViewBag.Categories = await _apiHelper.GetList<CategoryModel>("Categories")!;
            ViewBag.Publishers = await _apiHelper.GetList<PublisherModel>("Publishers")!;
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookBaseModel book)
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
            var book = await _apiHelper.GetByID<BookIndexModel>(id, "Books/GetBook")!;
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiHelper.Delete(id, "Books");
            return RedirectToAction("Manager");
        }
    }
}
