using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Helpers
{

    public class PersonRepo
    {
        public Person GetPerson(String userID)
        {
            Person person = new Person();
            
            string connectionString = ("Server=mssqlstud.fhict.local;" +
                                "Database=dbi439179_test;" +
                                "User Id=dbi439179_test;" +
                                "Password=MSSQL; " +
                                "TrustServerCertificate = true");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Person WHERE ID= @Id ", connection))
                {
                    sqlcommand.Parameters.AddWithValue("@Id", userID);
                    using (SqlDataReader reader = sqlcommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            person.Id = Convert.ToInt32(reader["ID"]);
                            person.Name = reader["Name"].ToString();
                            person.Age = Convert.ToInt32(reader["Age"]);
                            person.Gender = reader["Gender"].ToString();
                            person.Address = reader["Address"].ToString();

                        }
                    }


                }

            }



            //    using (MySqlConnection connection = new MySqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        using (MySqlCommand command = new MySqlCommand("SELECT * FROM student WHERE name = @name", connection))
            //        {
            //            command.Parameters.AddWithValue("@name", Request.Query["name"].ToString());


            return person;
        }

        public List<Person> GetPeople()
        {
            List<Person> People = new List<Person>();


            string connectionString = ("Server=mssqlstud.fhict.local;" +
                                "Database=dbi439179_test;" +
                                "User Id=dbi439179_test;" +
                                "Password=MSSQL; " +
                                "TrustServerCertificate = true");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Person ", connection))
                {

                    using (SqlDataReader reader = sqlcommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person();

                            person.Id = Convert.ToInt32(reader["ID"]);
                            person.Name = reader["Name"].ToString();
                            person.Age = Convert.ToInt32(reader["Age"]);
                            person.Gender = reader["Gender"].ToString();
                            person.Address = reader["Address"].ToString();
                            People.Add(person);
                        }
                    }


                }

            }

            return People;

        }
    }
}