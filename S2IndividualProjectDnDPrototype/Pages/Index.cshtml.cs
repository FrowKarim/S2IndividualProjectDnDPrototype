using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using DAL.Repos;
using LogicLayer.Entities;

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
            PersonRepo conn = new PersonRepo();

            People = conn.GetPeople();

            ViewData["Message"] = message;

        }
    }
}
