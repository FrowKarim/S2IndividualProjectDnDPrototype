using Microsoft.Data.SqlClient;
using LogicLayer.DTO;
using LogicLayer.Entities;
using LogicLayer.Interfaces;

namespace DAL.Repos;


public class NewCharacterRepo : INewCharacterRepo
{
    public NewCharacter GetNewCharacter(String NewCharacterId)
    {
        NewCharacter NewCharacter = new NewCharacter();

        string connectionString = ("Server=mssqlstud.fhict.local;" +
                            "Database=dbi439179_test;" +
                            "User Id=dbi439179_test;" +
                            "Password=MSSQL; " +
                            "TrustServerCertificate = true");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM NewCharacterSheet WHERE NewCharacterID= @Id ", connection))
            {
                sqlcommand.Parameters.AddWithValue("@Id", NewCharacterId);
                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        NewCharacter.Id = Convert.ToInt32(reader["NewCharacterID"]);
                        NewCharacter.UserId = Convert.ToInt32(reader["UserId"]);
                        NewCharacter.CampaignId = Convert.ToInt32(reader["CampaignId"]);
                        NewCharacter.Name = reader["NewCharacterName"].ToString();
                        NewCharacter.maxHealth = Convert.ToInt32(reader["MaxHP"]);
                        NewCharacter.currentHealth = Convert.ToInt32(reader["CurrentHP"]);
                        NewCharacter.maxStrength = Convert.ToInt32(reader["MaxStrength"]);
                        NewCharacter.currentStrength = Convert.ToInt32(reader["CurrentStrength"]);
                        NewCharacter.maxDexterity = Convert.ToInt32(reader["MaxDex"]);
                        NewCharacter.currentDexterity = Convert.ToInt32(reader["CurrentDex"]);
                        NewCharacter.maxWill = Convert.ToInt32(reader["MaxWill"]);
                        NewCharacter.currentWill = Convert.ToInt32(reader["CurrentWill"]);
                        NewCharacter.maxSpirit = Convert.ToInt32(reader["MaxSpirit"]);
                        NewCharacter.currentSpirit = Convert.ToInt32(reader["CurrentSpirit"]);
                        NewCharacter.Armor = Convert.ToInt32(reader["Armor"]);
                        NewCharacter.LeftHand = reader["LeftHand"].ToString();
                        NewCharacter.RightHand = reader["RightHand"].ToString();
                        NewCharacter.Body1 = reader["Body1"].ToString();
                        NewCharacter.Body2 = reader["Body2"].ToString();
                        NewCharacter.Backpack1 = reader["Backpack1"].ToString();
                        NewCharacter.Backpack2 = reader["Backpack2"].ToString();
                        NewCharacter.Backpack3 = reader["Backpack3"].ToString();
                        NewCharacter.Backpack4 = reader["Backpack4"].ToString();
                        NewCharacter.Backpack5 = reader["Backpack5"].ToString();
                        NewCharacter.Backpack6 = reader["Backpack6"].ToString();
                        NewCharacter.Notes = reader["Notes"].ToString();

                    }
                }


            }

        }
        

        return NewCharacter;
    }


    public NewCharacter AddNewCharacter(NewCharacter character)
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
                "INSERT INTO NewCharacterSheet (UserID, CampaignID, NewCharacterName, MaxHP, MaxStrength, MaxDex, MaxWill, MaxSpirit, Armor, CurrentHP, CurrentStrength, CurrentDex, CurrentWill, CurrentSpirit) " +
                "VALUES (@UserID, @CampaignID, @NewCharacterName, @MaxHP, @MaxStrength, @MaxDex, @MaxWill, @MaxSpirit, @Armor, @MaxHP, @MaxStrength, @MaxDex, @MaxWill, @MaxSpirit)",
                connection))
            {
                sqlcommand.Parameters.AddWithValue("@UserID", character.UserId);
                sqlcommand.Parameters.AddWithValue("@CampaignID", character.CampaignId);
                sqlcommand.Parameters.AddWithValue("@NewCharacterName", character.Name);
                sqlcommand.Parameters.AddWithValue("@MaxHP", character.maxHealth);
                sqlcommand.Parameters.AddWithValue("@MaxStrength", character.maxStrength);
                sqlcommand.Parameters.AddWithValue("@MaxDex", character.maxDexterity);
                sqlcommand.Parameters.AddWithValue("@MaxWill", character.maxWill);
                sqlcommand.Parameters.AddWithValue("@MaxSpirit", character.maxSpirit);
                sqlcommand.Parameters.AddWithValue("@Armor", character.Armor);
                sqlcommand.Parameters.AddWithValue("@CurrentHP", character.maxHealth);
                sqlcommand.Parameters.AddWithValue("@CurrentStrength", character.maxStrength);
                sqlcommand.Parameters.AddWithValue("@CurrentDex", character.maxDexterity);
                sqlcommand.Parameters.AddWithValue("@CurrentWill", character.maxWill);
                sqlcommand.Parameters.AddWithValue("@CurrentSpirit", character.maxSpirit);
                sqlcommand.ExecuteNonQuery();
            }
            return character;
        }
    }

    public List<NewCharacter> GetAllNewCharacters()
    {
        throw new NotImplementedException();
    }

    public List<NewCharacter> GetNewCharactersByCampaign(int campaignID)
{
    List<NewCharacter> characters = new List<NewCharacter>();

    string connectionString = ("Server=mssqlstud.fhict.local;" +
                        "Database=dbi439179_test;" +
                        "User Id=dbi439179_test;" +
                        "Password=MSSQL; " +
                        "TrustServerCertificate = true");

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM NewCharacterSheet WHERE CampaignId = @CampaignID", connection))
        {
            sqlcommand.Parameters.AddWithValue("@CampaignID", campaignID);
            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    NewCharacter character = new NewCharacter();
                    character.Id = Convert.ToInt32(reader["NewCharacterID"]);
                    character.UserId = Convert.ToInt32(reader["UserId"]);
                    character.CampaignId = Convert.ToInt32(reader["CampaignId"]);
                    character.Name = reader["NewCharacterName"].ToString();
                    character.maxHealth = Convert.ToInt32(reader["MaxHP"]);
                    character.currentHealth = Convert.ToInt32(reader["CurrentHP"]);
                    character.maxStrength = Convert.ToInt32(reader["MaxStrength"]);
                    character.currentStrength = Convert.ToInt32(reader["CurrentStrength"]);
                    character.maxDexterity = Convert.ToInt32(reader["MaxDex"]);
                    character.currentDexterity = Convert.ToInt32(reader["CurrentDex"]);
                    character.maxWill = Convert.ToInt32(reader["MaxWill"]);
                    character.currentWill = Convert.ToInt32(reader["CurrentWill"]);
                    character.maxSpirit = Convert.ToInt32(reader["MaxSpirit"]);
                    character.currentSpirit = Convert.ToInt32(reader["CurrentSpirit"]);
                    character.Armor = Convert.ToInt32(reader["Armor"]);
                    character.LeftHand = reader["LeftHand"].ToString();
                    character.RightHand = reader["RightHand"].ToString();
                    character.Body1 = reader["Body1"].ToString();
                    character.Body2 = reader["Body2"].ToString();
                    character.Backpack1 = reader["Backpack1"].ToString();
                    character.Backpack2 = reader["Backpack2"].ToString();
                    character.Backpack3 = reader["Backpack3"].ToString();
                    character.Backpack4 = reader["Backpack4"].ToString();
                    character.Backpack5 = reader["Backpack5"].ToString();
                    character.Backpack6 = reader["Backpack6"].ToString();
                    character.Notes = reader["Notes"].ToString();

                    characters.Add(character);
                }
            }
        }
    }

    return characters;
}

    public NewCharacter UpdateNewCharacter(NewCharacter NewCharacter)
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
                "UPDATE NewCharacterSheet " +
                "SET CurrentHP = @CurrentHP, CurrentStrength = @CurrentStrength, CurrentDex = @CurrentDex, " +
                "CurrentWill = @CurrentWill, CurrentSpirit = @CurrentSpirit, Armor = @Armor, LeftHand = @LeftHand, RightHand = @RightHand, " +
                "Body1 = @Body1, Body2 = @Body2, Backpack1 = @Backpack1, Backpack2 = @Backpack2, Backpack3 = @Backpack3, Backpack4 = @Backpack4, " +
                "Backpack5 = @Backpack5, Backpack6 = @Backpack6, Notes = @Notes " +
                "WHERE NewCharacterID = @ID",
                connection))
            {
                sqlcommand.Parameters.AddWithValue("@ID", NewCharacter.Id);
                sqlcommand.Parameters.AddWithValue("@CurrentHP", NewCharacter.currentHealth);
                sqlcommand.Parameters.AddWithValue("@CurrentStrength", NewCharacter.currentStrength);
                sqlcommand.Parameters.AddWithValue("@CurrentDex", NewCharacter.currentDexterity);
                sqlcommand.Parameters.AddWithValue("@CurrentWill", NewCharacter.currentWill);
                sqlcommand.Parameters.AddWithValue("@CurrentSpirit", NewCharacter.currentSpirit);
                sqlcommand.Parameters.AddWithValue("@Armor", NewCharacter.Armor);
                sqlcommand.Parameters.AddWithValue("@LeftHand", NewCharacter.LeftHand ?? "");
                sqlcommand.Parameters.AddWithValue("@RightHand", NewCharacter.RightHand ?? "");
                sqlcommand.Parameters.AddWithValue("@Body1", NewCharacter.Body1 ?? "");
                sqlcommand.Parameters.AddWithValue("@Body2", NewCharacter.Body2 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack1", NewCharacter.Backpack1 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack2", NewCharacter.Backpack2 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack3", NewCharacter.Backpack3 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack4", NewCharacter.Backpack4 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack5", NewCharacter.Backpack5 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack6", NewCharacter.Backpack6 ?? "");
                sqlcommand.Parameters.AddWithValue("@Notes", NewCharacter.Notes ?? "");
                sqlcommand.ExecuteNonQuery();
            }
        }
        return NewCharacter;
    }

    public NewCharacter DeleteNewCharacter(NewCharacter character)
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
                "DELETE FROM NewCharacterSheet WHERE NewCharacterID = @ID; ",
                connection))
            {
                sqlcommand.Parameters.AddWithValue("@ID", character.Id);
                sqlcommand.ExecuteNonQuery();
            }
            return character;
        }
       
    }
}

