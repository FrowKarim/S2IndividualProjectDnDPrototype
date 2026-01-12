using LogicLayer.Entities;
using LogicLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo : IUserRepo
    {

        public User GetUser(int UserId)
        {
            User User = new User();


            string connectionString = ("Server=mssqlstud.fhict.local;" +
                                "Database=dbi439179_test;" +
                                "User Id=dbi439179_test;" +
                                "Password=MSSQL; " +
                                "TrustServerCertificate = true");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlcommand = new SqlCommand("Select U.* , ch.* from Userdata as U join CharacterSheet as ch on ch.UserID = ch.UserID where U.UserID = @Id AND ch.UserID = @Id", connection))
                {
                    sqlcommand.Parameters.AddWithValue("@Id", UserId);
                    using (SqlDataReader reader = sqlcommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (User.Id == 0)
                            {
                                User.Id = Convert.ToInt32(reader["UserID"]);
                                User.Name = reader["UserName"].ToString();
                                User.Password = reader["Password"].ToString();
                            }
                           

                        }
                    }


                }

            }


            return User;
        }

        /// <summary>
        /// Authenticates a user by username and password.
        /// Returns the user if credentials match, otherwise returns null.
        /// </summary>
        public User AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            User user = new User();

            string connectionString = ("Server=mssqlstud.fhict.local;" +
                                "Database=dbi439179_test;" +
                                "User Id=dbi439179_test;" +
                                "Password=MSSQL; " +
                                "TrustServerCertificate = true");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(
                    "SELECT UserID, UserName, Password, Usertype FROM Userdata WHERE UserName = @UserName AND Password = @Password",
                    connection))
                {
                    sqlcommand.Parameters.AddWithValue("@UserName", username);
                    sqlcommand.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = sqlcommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user.Id = Convert.ToInt32(reader["UserID"]);
                            user.Name = reader["UserName"].ToString();
                            user.Password = reader["Password"].ToString();
                            user.IsDungeonMaster = Convert.ToBoolean(reader["Usertype"]);
                            return user;
                        }
                    }
                }
            }

            return null;
        }


        public User AddUser(User User)
        {

            string connectionString = ("Server=mssqlstud.fhict.local;" +
                                "Database=dbi439179_test;" +
                                "User Id=dbi439179_test;" +
                                "Password=MSSQL; " +
                                "TrustServerCertificate = true");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(
                    "INSERT INTO Userdata (UserName, Password) " +
                    "VALUES (@Name, @Password)",
                    connection))
                {
                    sqlcommand.Parameters.AddWithValue("@Name", User.Name);
                    sqlcommand.Parameters.AddWithValue("@Password", User.Password);

                    sqlcommand.ExecuteNonQuery();
                }
                return User;
            }
        }

        public List<User> GetAllUsers()
        {
            {
                List<User> Users = new List<User>();


                string connectionString = ("Server=mssqlstud.fhict.local;" +
                                    "Database=dbi439179_test;" +
                                    "User Id=dbi439179_test;" +
                                    "Password=MSSQL; " +
                                    "TrustServerCertificate = true");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM User ", connection))
                    {

                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User User = new User();

                                User.Id = Convert.ToInt32(reader["UserID"]);
                                User.Name = reader["Username"].ToString();
                                User.Password = reader["Password"].ToString();
                                Users.Add(User);
                            }
                        }


                    }

                }

                return Users;

            }
        }


        public void UpdateUser(User User)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(User User)
        {
            string connectionString = ("Server=mssqlstud.fhict.local;" +
                                "Database=dbi439179_test;" +
                                "User Id=dbi439179_test;" +
                                "Password=MSSQL; " +
                                "TrustServerCertificate = true");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlcommand = new SqlCommand(
                    "UPDATE Userdata    " +
                    " SET UserID = NULL     " +
                    "  WHERE UserID = @ID;  " +
                    "    DELETE FROM Userdata    " +
                    "  WHERE UserID = @ID; ",
                    connection))
                {
                    sqlcommand.Parameters.AddWithValue("@ID", User.Id);
                    sqlcommand.ExecuteNonQuery();
                }
                return User;
            }

        }
    }

}
