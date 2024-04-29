using Library.DAL.Helper;
using Library.DAL.Models;
using Library.DAL.Repositories.Authors;
using Library.DAL.Repositories.Books;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Library.DAL.Repositories.Contracts
{
	public class BookRepository : IBookRepository
	{
		private readonly IAuthorRepository _authorRepo;
		public BookRepository(IAuthorRepository authorRepository) => _authorRepo = authorRepository;

		public List<Book> getBooks(string searchString)
		{
			List<Book> books = [];

			SqlConnection con = new(DbConfig.ConnectionString);
			SqlCommand cmd = new("spGetBooks", con)
			{
				CommandType = CommandType.StoredProcedure
			};

			if (string.IsNullOrEmpty(searchString))
				searchString = string.Empty;

			cmd.Parameters.AddWithValue("@searchString", searchString);

			try
			{
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Book book = new()
					{
						Id = Convert.ToInt32(rdr["Id"]),
						Title = rdr["Title"].ToString(),
						ImagePath = rdr["ImagePath"].ToString(),
						Status = Convert.ToInt32(rdr["Status"]),
						ISBN = rdr["ISBN"].ToString(),
						AuthorId = Convert.ToInt32(rdr["AuthorId"]),
						Author = _authorRepo.getAuthorById(Convert.ToInt32(rdr["AuthorId"]))
					};
					books.Add(book);
				}
				rdr.Close();
				return (books);
			}
			catch (SqlException e)
			{
				throw new Exception($"SqlException error occurred: {e.Message}");
			}
			catch (DbException e)
			{
				throw new Exception($"DbException error occurred: {e.Message}");
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			finally
			{
				con?.Close();
				cmd?.Dispose();
			}
		}
	}
}