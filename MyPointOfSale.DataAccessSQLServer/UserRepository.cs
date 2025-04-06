using MyPointOfSale.Models;
using MyPointOfSale.Models.Share;
using System.Data.SqlClient;

namespace MyPointOfSale.DataAccessSQLServer
{
    public class UserRepository : ConnectionToSql
    {
        public UserRepository()
        {
        }

        public bool Login(User user)
        {
            using (SqlConnection connection = SqlConnection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText ="SELECT 1 [Id], [Username], [Password], [FirstName], [LastName], [Position], [Email] FROM [MyPointOfSaleDB].[dbo].[Users] WHERE [Username] = @Username AND [Password] = @Password";
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.Id = reader.GetInt32(0);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Email = reader.GetString(6);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}