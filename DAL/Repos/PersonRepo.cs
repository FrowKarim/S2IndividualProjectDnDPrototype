using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using DAL.Repos;
using LogicLayer.DTO;
using LogicLayer.Entities;
using LogicLayer.Interfaces;

namespace S2IndividualProjectDnDPrototype.Helpers
{

    public class PersonRepo : IPersonRepo
    {
        public Person GetPerson(String PersonID)
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
                    sqlcommand.Parameters.AddWithValue("@Id", PersonID);
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


        public void AddPerson(Person Person)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person Person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(Person Person)
        {
            throw new NotImplementedException();
        }
    }
}