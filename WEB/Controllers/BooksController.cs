using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Books")]
    public class BooksController : Controller
    {
        readonly ApiHelper _apiHelper;
        readonly IUrlHelperFactory _urlHelperFactory;
        public BooksController(ApiHelper apiHelper, IUrlHelperFactory urlHelperFactory)
        {
            _apiHelper = apiHelper;
            _urlHelperFactory = urlHelperFactory;
        }

        #region Index
        [HttpGet, Route("Index"), MyAuthorization(1, false, true)]
        public async Task<IActionResult> Index(int? authorId, int? categoryId, int? publisherId,
            bool? asc, int limit = 18, int page = 1)
        {
            var books = await _apiHelper.GetAll<Book>("Books");
            if (books == null) return BadRequest();

            //Filter
            if (authorId != null) books = books.Where(b => b.AuthorId == authorId);
            if (categoryId != null) books = books.Where(b => b.CategoryId == categoryId);
            if (publisherId != null) books = books.Where(b => b.PublisherId == publisherId);

            //Sort
            if (asc != null)
            {
                switch (asc)
                {
                    case true:
                        books = books.OrderBy(b => b.Title);
                        break;
                    case false:
                        books = books.OrderByDescending(b => b.Title);
                        break;
                }
            }

            //PageCount
            int bookCount = books.Count();
            ViewBag.PageCount = (bookCount % limit != 0) ? bookCount / limit + 1 : bookCount / limit;

            //Paging
            int skip = (page - 1) * limit;
            books = books.Skip(skip).Take(limit);

            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors");
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories");
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers");
            ViewBag.AuthorId = authorId;
            ViewBag.CategoryId = categoryId;
            ViewBag.PublisherId = publisherId;
            ViewBag.CurrentPage = page;
            return View(books);
        }
        #endregion
        #region Manager
        [HttpGet, Route("Manager"), MyAuthorization(2)]
        public async Task<IActionResult> Manager()
        {
            var books = await _apiHelper.GetAll<Book>("Books")!;

            foreach (var book in books!)
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

            if (TempData["ValidationErrors"] != null)
            {
                ViewBag.ValidationErrors = TempData["ValidationErrors"];
            }

            return View(new Book());
        }

        [HttpPost, Route("Create"), MyAuthorization(2)]
        public async Task<IActionResult> Create(Book book)
        {
            book.Id = 0;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                TempData["ValidationErrors"] = errors;
                return RedirectToAction("Create");
            }

            await _apiHelper.Post(book, "Books");
            return RedirectToAction("Manager");
        }
        #endregion
        #region Detail
        [HttpGet, Route("Detail")]
        public async Task<IActionResult> Detail(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            book!.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors")!;
            book!.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories")!;
            book!.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers")!;
            return View(book);
        }
        #endregion
        #region Edit
        [HttpGet, Route("Edit"), MyAuthorization(2)]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books");
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors");
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories");
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers");
            return View(book);
        }
        [HttpPost, Route("Edit"), MyAuthorization(2)]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _apiHelper.Put(book, "Books");
                return RedirectToAction("Detail", new { id = book.Id });
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
