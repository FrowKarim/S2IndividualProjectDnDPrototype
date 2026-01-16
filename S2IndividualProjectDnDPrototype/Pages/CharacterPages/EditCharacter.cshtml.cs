using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using LogicLayer.Services;
using DAL.Repos;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;

namespace S2IndividualProjectDnDPrototype.Pages.CharacterPages
{   
    public class EditCharacterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CharacterID { get; set; }

        [BindProperty]
        public Character? Character { get; set; }

        public IActionResult OnGet()
        {
            if (CharacterID <= 0)
            {
                return RedirectToPage("/Index");
            }

            CharacterService characterService = new CharacterService(new CharacterRepo());
            Character = characterService.GetCharacter(CharacterID.ToString());

            if (Character == null)
            {
                return RedirectToPage("/Index");
            }

            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {

                return Page();
            }
            else if (role == "Player")
            {
                return RedirectToPage("/AccessDenied");
            }
            else
                return RedirectToPage("/LoginPage");

            
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{      The reason I commented this out is because slots can be empty, idk how to make it valid while having NULL values here.
            //    return Page();
            //}

            if (Character == null || Character.Id <= 0)
            {
                return RedirectToPage("/Index");
            }

            CharacterService characterService = new CharacterService(new CharacterRepo());

            characterService.UpdateCharacter(Character);

            return RedirectToPage("/CharacterPages/CharacterPage", new { characterID = Character.Id });
        }
    }
}
