using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using S2IndividualProjectDnDPrototype.Models;
using S2IndividualProjectDnDPrototype.Helpers;

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
            PersonDataConnector conn = new PersonDataConnector();

            People = conn.GetPeople();

            ViewData["Message"] = message;

        }
    }
}
