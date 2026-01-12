using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User GetUser(int UserID);
        User AuthenticateUser(string username, string password);
        User AddUser(User User);
        void UpdateUser(User User);
        User DeleteUser(User User);
    }
}
