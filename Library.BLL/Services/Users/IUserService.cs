using Library.DAL.Models;

namespace Library.BLL.Services.Users
{
    public interface IUserService
    {
		User checkUserCredentials(string email, string password);
	}
}
