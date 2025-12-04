using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IPersonRepo
    {
        PersonDTO[] GetPeople();
        PersonDTO GetPerson(string PersonID);
        void AddPerson(PersonDTO Person);
        void UpdatePerson(PersonDTO Person);
        void DeletePerson(PersonDTO Person);

    }
}
