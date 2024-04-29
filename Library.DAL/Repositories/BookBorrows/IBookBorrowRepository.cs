using Library.DAL.Models;

namespace Library.DAL.Repositories.BookBorrows
{
	public interface IBookBorrowRepository
	{
		List<Book> getUserBorrowedBooks(int userId, string searchString);
		void borrowBook(Borrow borrow);
		void returnBook(int bookId);
	}
}
