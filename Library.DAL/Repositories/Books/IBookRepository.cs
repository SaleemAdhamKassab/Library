using Library.DAL.Models;

namespace Library.DAL.Repositories.Books
{
	public interface IBookRepository
	{
		List<Book> getBooks(string searchString);
	}
}