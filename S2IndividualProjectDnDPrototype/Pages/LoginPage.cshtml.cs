using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using LogicLayer.Entities;
using DAL;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public const string AdminSessionKey = "IsDungeonMaster";

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {
                return RedirectToPage("/Index");
            }
            else if (role == "Player")
            {
                return RedirectToPage("/PersonPage");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (User?.Name == "Hi" && User?.Password == "Bye")
            {
                // Store a simple flag in session to indicate DM/admin
                HttpContext.Session.SetString(AdminSessionKey, "true");

                return RedirectToPage("DMorPlayerPage");
            }
            else 
            { 
                ViewData["Message"] = "Credentials incorrect";
            return Page();
            }
        }
    }
}
