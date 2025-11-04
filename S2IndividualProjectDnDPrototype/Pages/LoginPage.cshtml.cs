using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (User.Name == "Hi" && User.Password == "Bye")
            {
                return new RedirectToPageResult("DMorPlayerPage");
            }
            else
            {
                ViewData["Message"] = "Credentials incorrect";
                return Page();

            }
        }

    }
}
