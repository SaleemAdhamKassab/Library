using Library.DAL.Models;

namespace Library.BLL.Services.BookBorrows
{
	public interface IBookBorrowService
	{
		List<Book> getUserBorrowedBooks(int userId, string searchString);
		void borrowBook(Borrow borrow);
		void returnBook(int bookId);
	}
}
