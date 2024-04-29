using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Models
{
	public class User
	{
		[Key]
        public int Id { get; set; }

		[Required,MaxLength(50)]
		public string FirstName { get; set; }

		[Required, MaxLength(50)]
		public string LastName { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
