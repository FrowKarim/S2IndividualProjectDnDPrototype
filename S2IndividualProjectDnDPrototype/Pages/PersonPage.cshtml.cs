using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class PersonPageModel : PageModel
    {
        public List<Person> People = new List<Person>();

        public void OnGet()
        {
            PersonService conn = new PersonService(new PersonRepo());
            People = conn.GetPeople();
        }
    }
}
