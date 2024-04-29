using Library.BLL.Services.BookBorrows;
using Library.DAL.Models;
using Library.PL.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Library.PL.Controllers
{
	public class BorrowedBooksController : Controller
	{
		private readonly IBookBorrowService _bookBorrowService;
		public BorrowedBooksController(IBookBorrowService bookBorrowService) => _bookBorrowService = bookBorrowService;


		public IActionResult Index(string searchString)
		{
			List<Book> userBorrowedBooks = _bookBorrowService.getUserBorrowedBooks(Shared.loggedUser.Id,searchString);
			return View(userBorrowedBooks);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult returnBook(int bookId)
		{
			_bookBorrowService.returnBook(bookId);
			return RedirectToAction(nameof(Index));
		}
	}
}