using Library.DAL.Models;
using System.Data.SqlClient;
using System.Data;
using Library.DAL.Helper;
using Library.DAL.Repositories.Authors;
using System.Data.Common;

namespace Library.DAL.Repositories.BookBorrows
{
	public class BookBorrowRepository : IBookBorrowRepository
	{
		private readonly IAuthorRepository _authorRepo;
		public BookBorrowRepository(IAuthorRepository authorRepository) => _authorRepo = authorRepository;

		public List<Book> getUserBorrowedBooks(int userId, string searchString)
		{
			List<Book> books = [];
			SqlConnection con = new(DbConfig.ConnectionString);
			SqlCommand cmd = new("spGetUserBorrowedBooks", con)
			{
				CommandType = CommandType.StoredProcedure
			};

			if (string.IsNullOrEmpty(searchString))
				searchString = string.Empty;
			cmd.Parameters.AddWithValue("@userId", userId);
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
		public void borrowBook(Borrow borrow)
		{
			SqlConnection con = new(DbConfig.ConnectionString);
			var cmd = new SqlCommand("spBorrowBook", con);

			try
			{
				con.Open();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Date", borrow.Date);
				cmd.Parameters.AddWithValue("@userId", borrow.UserId);
				cmd.Parameters.AddWithValue("@BookId", borrow.BookId);
				cmd.ExecuteNonQuery();
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
		public void returnBook(int bookId)
		{
			SqlConnection con = new(DbConfig.ConnectionString);
			var cmd = new SqlCommand("spReturnBook", con);
			try
			{
				con.Open();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@bookId", bookId);
				cmd.ExecuteNonQuery();
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
