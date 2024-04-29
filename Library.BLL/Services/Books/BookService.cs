using Library.DAL.Models;
using Library.DAL.Repositories.Books;

namespace Library.BLL.Services.Books
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _bookRepo;
		public BookService(IBookRepository bookRepo) => _bookRepo = bookRepo;

		public List<Book> getBooks(string searchString) => _bookRepo.getBooks(searchString);
	}
}
