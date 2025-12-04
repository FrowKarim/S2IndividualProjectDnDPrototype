using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DTO;
using LogicLayer.Entities;

namespace LogicLayer.Interfaces
{
    public interface IPersonRepo
    {
        Person[] GetPeople();
        Person GetPerson(string PersonID);
        void AddPerson(Person Person);
        void UpdatePerson(Person Person);
        void DeletePerson(Person Person);

    }
}
