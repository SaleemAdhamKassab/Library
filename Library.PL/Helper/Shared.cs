using Library.DAL.Models;

namespace Library.PL.Helper
{
	public static class Shared
	{
		public static User loggedUser = new();
		public enum enBookStatus { Available, Checked_Out }
	}
}
