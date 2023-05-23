﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Books")]
    public class BooksController : Controller
    {
        readonly ApiHelper _apiHelper;
        readonly IWebHostEnvironment _webHostEnvironment;
        public BooksController(ApiHelper apiHelper, IWebHostEnvironment webHostEnvironment)
        {
            _apiHelper = apiHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Index
        [MyAuthorizationFilter(1, false, true)]
        [HttpGet("Index")]
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
        [MyAuthorizationFilter(2)]
        [HttpGet("Manager/{page?}")]
        public async Task<IActionResult> Manager(int page = 1)
        {
            int limit = 50;
            int skip = (page - 1) * limit;
            var books = await _apiHelper.GetAll<Book>("Books");
            if (books == null)
            {
                //Thông báo
                return View();
            }
            books = books.Skip(skip).Take(limit);


            foreach (var book in books!)
            {
                book.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors");
                book.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories");
                book.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers");
            }
            return View(books);
        }
        #endregion
        #region Create
        [HttpGet("Create"), MyAuthorizationFilter(2)]
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors");
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories");
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers");

            return View();
        }

        [HttpPost("Create"), MyAuthorizationFilter(2)]
        public async Task<IActionResult> Create(Book book, IFormFile? coverImage)
        {
            ViewData["coverImage"] = coverImage;
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors");
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories");
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers");

            book.Id = 0;
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            if (book.Price % 50000 != 0)
            {
                ModelState.AddModelError("Price", "Price must be divisible by 5.");
            }
            if (coverImage != null)
            {
                if (coverImage.Length > 512 * 1024)
                {
                    ModelState.AddModelError("CoverImagePath", "Cover image size must be less than 512 KB.");
                    return View(book);
                }
                string extension = Path.GetExtension(coverImage.FileName);
                string fileName = book.ISBN.ToString() + extension;
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "book-cover-img", fileName);

                using var stream = new FileStream(imagePath, FileMode.Create);
                await coverImage.CopyToAsync(stream);

                book.CoverImagePath = "~/" + fileName;
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
        [HttpGet, Route("Edit"), MyAuthorizationFilter(2)]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books");
            ViewBag.Authors = await _apiHelper.GetAll<Author>("Authors");
            ViewBag.Categories = await _apiHelper.GetAll<Category>("Categories");
            ViewBag.Publishers = await _apiHelper.GetAll<Publisher>("Publishers");
            return View(book);
        }
        [HttpPost, Route("Edit"), MyAuthorizationFilter(2)]
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
        [HttpGet, Route("Delete"), MyAuthorizationFilter(2)]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books")!;
            return View(book);
        }
        [HttpPost, Route("DeleteConfirmed"), MyAuthorizationFilter(2)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiHelper.Delete<Book>(id, "Books");
            return RedirectToAction("Manager");
        }
        #endregion
    }
}
