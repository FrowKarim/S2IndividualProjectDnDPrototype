using LogicLayer.DTO;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Models
{
    public class UserViewModel
    {

        public UserViewModel() 
        { 
        // Constructor for the class
        
        }

        public int Id { get; set; } //Properties of user

        public string Name { get; set; } //Properties of user
        public string Password { get; set; } //Properties of user

        public bool IsDungeonMaster { get; set; } //Properties of user


    }
}
