using Library.DAL.Models;

namespace Library.BLL.Services.Users
{
    public interface IUserService
    {
		//bool loginResult(string email, string password);
		User checkUserCredentials(string email, string password);
	}
}
