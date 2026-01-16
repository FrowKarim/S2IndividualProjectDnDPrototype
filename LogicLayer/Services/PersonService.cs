using LogicLayer.Entities;
using LogicLayer.Interfaces;

namespace LogicLayer.Services
{
    public class PersonService
    {
        private readonly IPersonRepo _personRepo;

        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public Person GetPerson(string personID)
        {
            return _personRepo.GetPerson(personID);
        }

        public List<Person> GetPeople()
        {
            return _personRepo.GetPeople();
        }
    }
}
