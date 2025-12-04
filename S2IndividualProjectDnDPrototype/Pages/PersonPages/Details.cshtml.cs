using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Pages.PersonPages
{
    public class DetailsModel : PageModel
    {
        
        
        public void OnGet()
        {
            
            PersonDataConnector conn = new PersonDataConnector();
            string userId = Request.Query["userID"].ToString();
            PersonViewModel SinglePerson = conn.GetPerson(userId);
           
        }

        
        
        public PersonViewModel getSinglePerson()
        {
            PersonDataConnector conn = new PersonDataConnector();
            string userId = Request.Query["userID"].ToString();
            PersonViewModel SinglePerson = conn.GetPerson(userId);
            return SinglePerson;
        }

    }
}
