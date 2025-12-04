using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using S2IndividualProjectDnDPrototype.Helpers;
using LogicLayer.Entities;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages.PersonPages
{
    public class DetailsModel : PageModel
    {
        
        
        public void OnGet()
        {
            
            PersonRepo conn = new PersonRepo();
            string userId = Request.Query["userID"].ToString();
            Person SinglePerson = conn.GetPerson(userId);
           
        }

        
        
        public Person getSinglePerson()
        {
            PersonRepo conn = new PersonRepo();
            string userId = Request.Query["userID"].ToString();
            Person SinglePerson = conn.GetPerson(userId);
            return SinglePerson;
        }

    }
}
