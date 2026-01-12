using Microsoft.Data.SqlClient;
using LogicLayer.DTO;
using LogicLayer.Entities;
using LogicLayer.Interfaces;

namespace DAL.Repos;


public class CharacterRepo : ICharacterRepo
{
    public Character GetCharacter(String CharacterId)
    {
        Character Character = new Character();

        string connectionString = ("Server=mssqlstud.fhict.local;" +
                            "Database=dbi439179_test;" +
                            "User Id=dbi439179_test;" +
                            "Password=MSSQL; " +
                            "TrustServerCertificate = true");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM CharacterSheet WHERE CharacterID= @Id ", connection))
            {
                sqlcommand.Parameters.AddWithValue("@Id", CharacterId);
                using (SqlDataReader reader = sqlcommand.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Character.Id = Convert.ToInt32(reader["CharacterID"]);
                        Character.UserId = Convert.ToInt32(reader["UserId"]);
                        Character.CampaignId = Convert.ToInt32(reader["CampaignId"]);
                        Character.Name = reader["CharacterName"].ToString();
                        Character.maxHealth = Convert.ToInt32(reader["MaxHP"]);
                        Character.currentHealth = Convert.ToInt32(reader["CurrentHP"]);
                        Character.maxStrength = Convert.ToInt32(reader["MaxStrength"]);
                        Character.currentStrength = Convert.ToInt32(reader["CurrentStrength"]);
                        Character.maxDexterity = Convert.ToInt32(reader["MaxDex"]);
                        Character.currentDexterity = Convert.ToInt32(reader["CurrentDex"]);
                        Character.maxWill = Convert.ToInt32(reader["MaxWill"]);
                        Character.currentWill = Convert.ToInt32(reader["CurrentWill"]);
                        Character.maxSpirit = Convert.ToInt32(reader["MaxSpirit"]);
                        Character.currentSpirit = Convert.ToInt32(reader["CurrentSpirit"]);
                        Character.Armor = Convert.ToInt32(reader["Armor"]);
                        Character.LeftHand = reader["LeftHand"].ToString();
                        Character.RightHand = reader["RightHand"].ToString();
                        Character.Body1 = reader["Body1"].ToString();
                        Character.Body2 = reader["Body2"].ToString();
                        Character.Backpack1 = reader["Backpack1"].ToString();
                        Character.Backpack2 = reader["Backpack2"].ToString();
                        Character.Backpack3 = reader["Backpack3"].ToString();
                        Character.Backpack4 = reader["Backpack4"].ToString();
                        Character.Backpack5 = reader["Backpack5"].ToString();
                        Character.Backpack6 = reader["Backpack6"].ToString();
                        Character.Notes = reader["Notes"].ToString();

                    }
                }


            }

        }
        

        return Character;
    }


    public Character AddCharacter(Character character)
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
                "INSERT INTO CharacterSheet (UserID, CampaignID, CharacterName, MaxHP, MaxStrength, MaxDex, MaxWill, MaxSpirit, Armor, CurrentHP, CurrentStrength, CurrentDex, CurrentWill, CurrentSpirit) " +
                "VALUES (@UserID, @CampaignID, @CharacterName, @MaxHP, @MaxStrength, @MaxDex, @MaxWill, @MaxSpirit, @Armor, @MaxHP, @MaxStrength, @MaxDex, @MaxWill, @MaxSpirit)",
                connection))
            {
                sqlcommand.Parameters.AddWithValue("@UserID", character.UserId);
                sqlcommand.Parameters.AddWithValue("@CampaignID", character.CampaignId);
                sqlcommand.Parameters.AddWithValue("@CharacterName", character.Name);
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

    public List<Character> GetAllCharacters()
    {
        throw new NotImplementedException();
    }

    public List<Character> GetCharactersByCampaign(int campaignID)
{
    List<Character> characters = new List<Character>();

    string connectionString = ("Server=mssqlstud.fhict.local;" +
                        "Database=dbi439179_test;" +
                        "User Id=dbi439179_test;" +
                        "Password=MSSQL; " +
                        "TrustServerCertificate = true");

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand sqlcommand = new SqlCommand("SELECT * FROM CharacterSheet WHERE CampaignId = @CampaignID", connection))
        {
            sqlcommand.Parameters.AddWithValue("@CampaignID", campaignID);
            using (SqlDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Character character = new Character();
                    character.Id = Convert.ToInt32(reader["CharacterID"]);
                    character.UserId = Convert.ToInt32(reader["UserId"]);
                    character.CampaignId = Convert.ToInt32(reader["CampaignId"]);
                    character.Name = reader["CharacterName"].ToString();
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

    public Character UpdateCharacter(Character Character)
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
                "UPDATE CharacterSheet " +
                "SET CurrentHP = @CurrentHP, CurrentStrength = @CurrentStrength, CurrentDex = @CurrentDex, " +
                "CurrentWill = @CurrentWill, CurrentSpirit = @CurrentSpirit, Armor = @Armor, LeftHand = @LeftHand, RightHand = @RightHand, " +
                "Body1 = @Body1, Body2 = @Body2, Backpack1 = @Backpack1, Backpack2 = @Backpack2, Backpack3 = @Backpack3, Backpack4 = @Backpack4, " +
                "Backpack5 = @Backpack5, Backpack6 = @Backpack6, Notes = @Notes " +
                "WHERE CharacterID = @ID",
                connection))
            {
                sqlcommand.Parameters.AddWithValue("@ID", Character.Id);
                sqlcommand.Parameters.AddWithValue("@CurrentHP", Character.currentHealth);
                sqlcommand.Parameters.AddWithValue("@CurrentStrength", Character.currentStrength);
                sqlcommand.Parameters.AddWithValue("@CurrentDex", Character.currentDexterity);
                sqlcommand.Parameters.AddWithValue("@CurrentWill", Character.currentWill);
                sqlcommand.Parameters.AddWithValue("@CurrentSpirit", Character.currentSpirit);
                sqlcommand.Parameters.AddWithValue("@Armor", Character.Armor);
                sqlcommand.Parameters.AddWithValue("@LeftHand", Character.LeftHand ?? "");
                sqlcommand.Parameters.AddWithValue("@RightHand", Character.RightHand ?? "");
                sqlcommand.Parameters.AddWithValue("@Body1", Character.Body1 ?? "");
                sqlcommand.Parameters.AddWithValue("@Body2", Character.Body2 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack1", Character.Backpack1 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack2", Character.Backpack2 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack3", Character.Backpack3 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack4", Character.Backpack4 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack5", Character.Backpack5 ?? "");
                sqlcommand.Parameters.AddWithValue("@Backpack6", Character.Backpack6 ?? "");
                sqlcommand.Parameters.AddWithValue("@Notes", Character.Notes ?? "");
                sqlcommand.ExecuteNonQuery();
            }
        }
        return Character;
    }

    public Character DeleteCharacter(Character character)
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
                "DELETE FROM CharacterSheet WHERE CharacterID = @ID; ",
                connection))
            {
                sqlcommand.Parameters.AddWithValue("@ID", character.Id);
                sqlcommand.ExecuteNonQuery();
            }
            return character;
        }
       
    }
}

