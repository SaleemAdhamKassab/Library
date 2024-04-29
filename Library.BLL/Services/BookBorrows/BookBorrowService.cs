using Library.DAL.Models;
using Library.DAL.Repositories.BookBorrows;

namespace Library.BLL.Services.BookBorrows
{
	public class BookBorrowService : IBookBorrowService
	{
		private readonly IBookBorrowRepository _bookBorrowRepo;
		public BookBorrowService(IBookBorrowRepository bookBorrowRepository) => _bookBorrowRepo = bookBorrowRepository;

		public List<Book> getUserBorrowedBooks(int userId, string searchString) => _bookBorrowRepo.getUserBorrowedBooks(userId, searchString);
		public void borrowBook(Borrow borrow) => _bookBorrowRepo.borrowBook(borrow);
		public void returnBook(int bookId) => _bookBorrowRepo.returnBook(bookId);
	}
}