using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace S2IndividualProjectDnDPrototype.Pages.PersonPages
{
    public class DetailsModel : PageModel
    {
        
        
        public void OnGet()
        {

            PersonService conn = new PersonService(new PersonRepo());
            string userId = Request.Query["userID"].ToString();
            Person SinglePerson = conn.GetPerson(userId);
           
        }

        
        
        public Person getSinglePerson()
        {
            PersonService conn = new PersonService(new PersonRepo());
            string userId = Request.Query["userID"].ToString();
            Person SinglePerson = conn.GetPerson(userId);
            return SinglePerson;
        }

    }
}
