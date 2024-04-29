using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Models
{
	public class Borrow
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int BookId { get; set; }
	}
}
