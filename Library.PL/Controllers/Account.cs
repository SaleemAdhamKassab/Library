using Library.BLL.Services.Users;
using Library.DAL.Models;
using Library.PL.Helper;
using Library.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.PL.Controllers
{
	public class Account : Controller
	{
		private readonly IUserService _userService;
		public Account(IUserService userService) => _userService = userService;

		public IActionResult login()
		{
			LoginViewModel model = new();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid view model");

			try
			{
				User user = _userService.checkUserCredentials(model.Email, model.Password);

				if (user.Id != 0)
				{
					Shared.loggedUser = user;
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Invalid login Attempt");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult logout()
		{
			Shared.loggedUser = new User();
			return RedirectToAction("Index", "Home");
		}
	}
}