using Library.DAL.Models;

namespace Library.DAL.Repositories.Authors
{
	public interface IAuthorRepository
	{
		Author getAuthorById(int id);
	}
}
