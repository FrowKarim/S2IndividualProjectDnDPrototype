using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class PersonPageModel : PageModel
    {
        public List<Person> People = new List<Person>();

        public void OnGet()
        {
            PersonDataConnector conn = new PersonDataConnector();
            People = conn.GetPeople();
        }
    }
}
