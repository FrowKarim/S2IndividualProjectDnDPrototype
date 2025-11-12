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
        
        
        public void OnGet()
        {
            
            PersonDataConnector conn = new PersonDataConnector();
            string userId = Request.Query["userID"].ToString();
            Person SinglePerson = conn.GetPerson(userId);
            //People = conn.GetPeople();
        }

        public Person GetPerson()
        {
            //string userId = Request.Query["userID"].ToString();
            //PersonDataConnector conn = new PersonDataConnector();
            //return conn.GetPerson(userId);

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
                    sqlcommand.Parameters.AddWithValue("@Id", Request.Query["userID"].ToString());
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


            return person;
        }

        public Person getSinglePerson()
        {
            PersonDataConnector conn = new PersonDataConnector();
            string userId = Request.Query["userID"].ToString();
            Person SinglePerson = conn.GetPerson(userId);
            return SinglePerson;
        }

    }
}
