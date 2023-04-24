using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Helpers;

namespace WEB.Controllers
{
    [Route("Books")]
    public class BooksController : Controller
    {
        readonly ApiHelper _apiHelper;
        public BooksController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet, Route("Index")]
        public async Task<IActionResult> Index()
        {
            var books = await _apiHelper.GetAll<Book>("Books")!;
            return View(books);
        }
        #region Manager
        [HttpGet, Route("Manager"), MyAuthorization(2)]
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
        #endregion
        #region Create
        [HttpGet, Route("Create"), MyAuthorization(2)]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors")!;
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories")!;
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers")!;
            return View();
        }
        [HttpPost, Route("Create"), MyAuthorization(2)]
        public async Task<IActionResult> Create(Book book)
        {
            book.BookId = 0;
            if (ModelState.IsValid)
            {
                await _apiHelper.Post(book, "Books");
                return RedirectToAction("Manager");
            }
            ViewBag.ErrorMessenger = "Thông tin nhập không hợp lệ!";
            return View(book);
        }
        #endregion
        #region Detail
        [HttpGet, Route("Detail")]
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            book.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors")!;
            book.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories")!;
            book.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers")!;
            return View(book);
        }
        #endregion
        #region Edit
        [HttpGet, Route("Edit"), MyAuthorization(2)]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors")!;
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories")!;
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers")!;
            return View(book);
        }
        [HttpPost, Route("Edit"), MyAuthorization(2)]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _apiHelper.Put(book, "Books");
                return RedirectToAction("Detail", new { id = book.BookId });
            }
            return View(book);
        }
        #endregion
        #region Delete
        [HttpGet, Route("Delete"), MyAuthorization(2)]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            return View(book);
        }
        [HttpPost, Route("DeleteConfirmed"), MyAuthorization(2)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiHelper.Delete<Book>(id, "Books");
            return RedirectToAction("Manager");
        }
        #endregion
    }
}
