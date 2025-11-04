using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Pages.PersonPages
{
    public class DetailsModel : PageModel
    {
        public int ID { get; set; }

        public void OnGet()
        {

            PersonDataConnector conn = new PersonDataConnector();

            //People = conn.GetPeople();
        }
    }
}
