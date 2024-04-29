using Library.DAL.Models;
using Library.DAL.Repositories.Users;

namespace Library.BLL.Services.Users
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;
		public UserService(IUserRepository userRepository) => _userRepo = userRepository;

		public User checkUserCredentials(string email, string password) => _userRepo.checkUserCredentials(email, password);
	}
}