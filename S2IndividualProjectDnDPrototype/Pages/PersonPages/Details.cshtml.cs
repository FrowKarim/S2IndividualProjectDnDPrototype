using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Pages.PersonPages
{
    public class DetailsModel : PageModel
    {
        public int ID { get; set; }

        public void OnGet()
        {
            
            PersonDataConnector conn = new PersonDataConnector();
            Person SinglePerson = conn.GetPerson();
            //People = conn.GetPeople();
        }

        public Person GetPerson()
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
                using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Person WHERE Name= @name ", connection))
                {
                    sqlcommand.Parameters.AddWithValue("@name", Request.Query["name"].ToString());
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
    }
}
