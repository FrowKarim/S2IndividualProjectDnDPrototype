using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class IndexModel : PageModel
    {

        public List<Person> People = new List<Person>();



        public string message { get; set; }



        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PersonService conn = new PersonService(new PersonRepo());

            People = conn.GetPeople();

            ViewData["Message"] = message;

        }
    }
}
