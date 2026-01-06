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
    public class CampaignRepo : ICampaignRepo
    {
        
            public Campaign GetCampaign(String CampaignId)
            {
                Campaign Campaign = new Campaign();

                string connectionString = ("Server=mssqlstud.fhict.local;" +
                                    "Database=dbi439179_test;" +
                                    "User Id=dbi439179_test;" +
                                    "Password=MSSQL; " +
                                    "TrustServerCertificate = true");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Campaign WHERE CampaignID= @Id ", connection))
                    {
                        sqlcommand.Parameters.AddWithValue("@Id", CampaignId);
                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Campaign.Id = Convert.ToInt32(reader["CampaignID"]);
                                

                            }
                        }


                    }

                }


                return Campaign;
            }


            public Campaign AddCampaign(Campaign Campaign)
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
                        "INSERT INTO Campaign (CampaignID, CampaignName) " +
                        "VALUES (@CampaignID, @CampaignName )",
                        connection))
                    {
                        sqlcommand.Parameters.AddWithValue("@CampaignID", Campaign.Id);
                        sqlcommand.Parameters.AddWithValue("@CampaignName", Campaign.Name);
                        
                        sqlcommand.ExecuteNonQuery();
                    }
                    return Campaign;
                }
            }

            public List<Campaign> GetAllCampaigns()
            {
                throw new NotImplementedException();
            }


            public void UpdateCampaign(Campaign Campaign)
            {
                throw new NotImplementedException();
            }

            public Campaign DeleteCampaign(Campaign Campaign)
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
                        "DELETE FROM Campaigns WHERE Id = @ID; ",
                        connection))
                    {
                        sqlcommand.Parameters.AddWithValue("@ID", Campaign.Id);
                        sqlcommand.ExecuteNonQuery();
                    }
                    return Campaign;
                }

            }
        }
    
}
