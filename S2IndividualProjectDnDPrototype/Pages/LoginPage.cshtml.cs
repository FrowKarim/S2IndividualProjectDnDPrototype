using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using LogicLayer.Entities;
using LogicLayer.Services;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public const string AdminSessionKey = "IsDungeonMaster";
        public const string UserIDSessionKey = "UserID";
        public const int AccountCampaignID = 0;


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
            // Validate input fields
            if (string.IsNullOrWhiteSpace(User?.Name) || string.IsNullOrWhiteSpace(User?.Password))
            {
                ViewData["Message"] = "Username and password are required.";
                return Page();
            }

            // Authenticate user against database
            UserService userService = new UserService(new UserRepo());
            User authenticatedUser = userService.AuthenticateUser(User.Name, User.Password);

            if (authenticatedUser != null)
            {
                // Set session variables with user ID
                HttpContext.Session.SetInt32(UserIDSessionKey, authenticatedUser.Id);
                HttpContext.Session.SetInt32(nameof(AccountCampaignID), 1);

                // Redirect to DMorPlayerPage to ask for role selection
                return RedirectToPage("/DMorPlayerPage");
            }
            else
            {
                ViewData["Message"] = "Username or password is incorrect.";
                return Page();
            }
        }
    }
}
