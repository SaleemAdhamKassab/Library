using Library.DAL.Models;

namespace Library.BLL.Services.Books
{
	public interface IBookService
	{
		List<Book> getBooks(string searchString);
	}
}
