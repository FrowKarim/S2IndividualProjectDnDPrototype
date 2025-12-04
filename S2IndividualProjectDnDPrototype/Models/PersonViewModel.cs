using LogicLayer.DTO;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Models
{
    public class PersonViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Age { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public PersonViewModel()
        { 
        
        }

    }
}
