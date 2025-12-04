using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Models;
using DAL.Repos;
using LogicLayer.Entities;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class PersonPageModel : PageModel
    {
        public List<Person> People = new List<Person>();

        public void OnGet()
        {
            PersonRepo conn = new PersonRepo();
            People = conn.GetPeople();
        }
    }
}
