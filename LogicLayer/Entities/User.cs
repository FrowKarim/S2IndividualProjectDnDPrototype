using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class User
    {

        public User()
        {
            // Constructor for the class

        }

        public int Id { get; set; } //Properties of user

        public string Name { get; set; } //Properties of user
        public string Password { get; set; } //Properties of user

        public bool IsDungeonMaster { get; set; } //Properties of user


    }
}
