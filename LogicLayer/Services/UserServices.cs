using LogicLayer.Entities;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class UserService
    {
        private IUserRepo _UserRepo;
        public UserService(IUserRepo _IUserRepo)
        {
            _UserRepo = _IUserRepo;
        }
        public User GetUser(int UserID)
        {

            return _UserRepo.GetUser(UserID);
        }

        public void CreateUser(User User)
        {

            _UserRepo.AddUser(User);
        }

        public User DeleteUser(User User)
        {
            return _UserRepo.DeleteUser(User);
        }

        
        public User AuthenticateUser(string username, string password)
        {
            return _UserRepo.AuthenticateUser(username, password);
        }
    }

}

