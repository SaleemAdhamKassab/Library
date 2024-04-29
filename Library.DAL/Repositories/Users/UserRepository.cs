using Library.DAL.Helper;
using System.Data.SqlClient;
using System.Data;
using Library.DAL.Models;
using System.Data.Common;

namespace Library.DAL.Repositories.Users
{
	public class UserRepository : IUserRepository
	{
		public User checkUserCredentials(string email, string password)
		{
			User user = new();
			SqlConnection con = new(DbConfig.ConnectionString);
			SqlCommand cmd = new("spCheckUserCredentials", con)
			{
				CommandType = CommandType.StoredProcedure
			};
			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@password", DbConfig.encodePassword(password));

			try
			{
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					user.Id = Convert.ToInt32(rdr["Id"]);
					user.FirstName = rdr["FirstName"].ToString();
					user.LastName = rdr["LastName"].ToString();
					user.Email = rdr["Email"].ToString();
					user.Password = rdr["Password"].ToString();
				}
				rdr.Close();
				return user;
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