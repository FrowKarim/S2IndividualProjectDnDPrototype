using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;
using LogicLayer.Services;


namespace S2IndividualProjectDnDPrototype.Pages
{
    public class CreateCharacterModel : PageModel
    {
        [BindProperty]
        public Character Character { get; set; }
        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {
                return Page();
            }
            else if (role == "Player")
            {
                return RedirectToPage("/Index");
            }
            else
                return RedirectToPage("/LoginPage");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Here you would typically save the character to the database
            // For example:
            // CharacterRepository.AddCharacter(Character);
            
            return RedirectToPage("/CharacterCreatedConfirmation");
        }

    }
}
