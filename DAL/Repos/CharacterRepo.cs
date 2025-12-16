using Microsoft.Data.SqlClient;
using LogicLayer.DTO;
using LogicLayer.Entities;
namespace DAL.Repos;


public class CharacterRepo
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
                "INSERT INTO CharacterSheet (CharacterName, MaxHP, MaxStrength, MaxDex, MaxWill, MaxSpirit, Armor, CurrentHP, CurrentStrength, CurrentDex, CurrentWill, CurrentSpirit) " +
                "VALUES (@CharacterName, @MaxHP, @MaxStrength, @MaxDex, @MaxWill, @MaxSpirit, @Armor, @MaxHP, @MaxStrength, @MaxDex, @MaxWill, @MaxSpirit)",
                connection))
            {
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
}
