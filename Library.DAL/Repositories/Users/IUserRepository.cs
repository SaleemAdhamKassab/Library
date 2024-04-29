using Library.DAL.Models;

namespace Library.DAL.Repositories.Users
{
	public interface IUserRepository
	{
		User checkUserCredentials(string email, string password);
	}
}
