using Library.BLL.Services.BookBorrows;
using Library.BLL.Services.Books;
using Library.DAL.Models;
using Library.PL.Helper;
using Library.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.PL.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBookService _bookService;
		private readonly IBookBorrowService _bookBorrowService;

		public HomeController(IBookService bookService, IBookBorrowService bookBorrowService)
		{
			_bookService = bookService;
			_bookBorrowService = bookBorrowService;
		}

		public IActionResult Index(string searchString)
		{
			List<Book> books = _bookService.getBooks(searchString);

			return View(books);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult borrowBook(int bookId)
		{
			Borrow borrow = new()
			{
				BookId = bookId,
				Date = DateTime.Now,
				UserId = Shared.loggedUser.Id
			};
			_bookBorrowService.borrowBook(borrow);
			return RedirectToAction(nameof(Index));
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
