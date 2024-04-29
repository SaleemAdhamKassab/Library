using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }

		[Required,MaxLength(50)]
		public string FirstName { get; set; }

		[Required, MaxLength(50)]
		public string LastName { get; set; }

		public List<Book> Books { get; set; }
	}
}
