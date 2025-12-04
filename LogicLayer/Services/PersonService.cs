using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.Services
{
    public class PersonService
    {
        private IPersonRepo _personRepo;

        public Person GetPerson(string PersonID)
        {
            return _personRepo.GetPerson(PersonID);
        }

    }
}
