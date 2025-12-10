using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using LogicLayer.Entities;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class DMorPlayerPageModel : PageModel
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
            // Model binding sets User.IsDungeonMaster from the radio buttons.
            if (User?.IsDungeonMaster == true)
            {
                HttpContext.Session.SetString(AdminSessionKey, "DungeonMaster");
                // User.IsDungeonMaster is already true; redirect to DM page
                return RedirectToPage("/Index");
            }

            // Not a DM -> set session as player and redirect
            HttpContext.Session.SetString(AdminSessionKey, "Player");
            return RedirectToPage("/PersonPage");
        }
    }
}
