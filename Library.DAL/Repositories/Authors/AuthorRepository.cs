using System.Data.SqlClient;
using System.Data;
using Library.DAL.Models;
using Library.DAL.Helper;
using System.Data.Common;

namespace Library.DAL.Repositories.Authors
{
	public class AuthorRepository : IAuthorRepository
	{
		public Author getAuthorById(int id)
		{
			Author author = new();
			SqlConnection con = new(DbConfig.ConnectionString);
			SqlCommand cmd = new("spGetAuthorById", con)
			{
				CommandType = CommandType.StoredProcedure
			};
			cmd.Parameters.AddWithValue("@id", id);

			try
			{
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					author.Id = Convert.ToInt32(rdr["Id"]);
					author.FirstName = rdr["FirstName"].ToString();
					author.LastName = rdr["LastName"].ToString();
				}
				rdr.Close();
				return author;
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