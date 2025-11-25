namespace DAL.Models
{
    public class UserDTO
    {

        public UserDTO() 
        { 
        // Constructor for the class
        
        }

        public int Id { get; set; } //Properties of user

        public string Name { get; set; } //Properties of user
        public string Password { get; set; } //Properties of user

        public bool IsDungeonMaster { get; set; } //Properties of user


    }
}
