using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public string Title { get; set; }

		[Required]
		public string ImagePath { get; set; }

		[Required]
		public int Status { get; set; }

        [Required]
        public string ISBN { get; set; }

        public int AuthorId { get; set; }
		public Author Author { get; set; }
	}
}
