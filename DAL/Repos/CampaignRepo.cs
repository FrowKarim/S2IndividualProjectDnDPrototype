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
        
            public Campaign GetCampaign(int CampaignId)
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
                    using (SqlCommand sqlcommand = new SqlCommand("Select c.* , ch.* from campaign as c join CharacterSheet as ch on ch.CampaignID = c.CampaignID where c.CampaignID = @Id ", connection))
                    {
                        sqlcommand.Parameters.AddWithValue("@Id", CampaignId);
                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                           while (reader.Read())
                            {
                            if (Campaign.Id == 0)
                            {
                                Campaign.Id = Convert.ToInt32(reader["CampaignID"]);
                                Campaign.Name = reader["CampaignName"].ToString();
                                Campaign.Owner = reader["CampaignOwner"].ToString();
                                Campaign.Description = reader["Description"].ToString();
                            }
                                Character character = new Character(); 
                                character.Id = Convert.ToInt32(reader["CharacterID"]);
                                character.CampaignId = Convert.ToInt32(reader["CampaignID"]);
                                character.UserId = Convert.ToInt32(reader["UserID"]);
                                character.Name = reader["CharacterName"].ToString();
                                
                            Campaign.Characters.Add(character);


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
                        "INSERT INTO Campaign (CampaignName, CampaignOwner, Description) " +
                        "VALUES (@CampaignName, @CampaignOwner, @Description )",
                        connection))
                    {
                        sqlcommand.Parameters.AddWithValue("@CampaignName", Campaign.Name);
                        sqlcommand.Parameters.AddWithValue("@CampaignOwner", Campaign.Owner);
                        sqlcommand.Parameters.AddWithValue("@Description", Campaign.Description);

                    sqlcommand.ExecuteNonQuery();
                    }
                    return Campaign;
                }
            }

            public List<Campaign> GetAllCampaigns()
            {
            {
                List<Campaign> Campaigns = new List<Campaign>();


                string connectionString = ("Server=mssqlstud.fhict.local;" +
                                    "Database=dbi439179_test;" +
                                    "User Id=dbi439179_test;" +
                                    "Password=MSSQL; " +
                                    "TrustServerCertificate = true");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Campaign ", connection))
                    {

                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Campaign campaign = new Campaign();

                                campaign.Id = Convert.ToInt32(reader["CampaignID"]);
                                campaign.Name = reader["CampaignName"].ToString();
                                campaign.Owner = reader["CampaignOwner"].ToString();
                                campaign.Description = reader["Description"].ToString();
                                Campaigns.Add(campaign);
                            }
                        }


                    }

                }

                return Campaigns;

            }
        }


            public Campaign UpdateCampaign(Campaign Campaign)
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
                    "UPDATE Campaign" +
                    "SET (CampaignName = @CampaignName, CampaignOwner = @CampaignOwner, Description = @Description) " + 
                    "WHERE CampaignID = @ID" ,
                    connection))
                {
                    sqlcommand.Parameters.AddWithValue("@CampaignName", Campaign.Name);
                    sqlcommand.Parameters.AddWithValue("@CampaignOwner", Campaign.Owner);
                    sqlcommand.Parameters.AddWithValue("@Description", Campaign.Description);
                    sqlcommand.Parameters.AddWithValue("@ID", Campaign.Id);
                    sqlcommand.ExecuteNonQuery();
                }
                return Campaign;
            }
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
                        "UPDATE CharacterSheet     " +
                        " SET CampaignID = NULL     " +
                        "  WHERE CampaignID = @ID;  " +
                        "    DELETE FROM Campaign    " +
                        "  WHERE CampaignID = @ID; ",
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
