using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using LogicLayer.Services;
using DAL.Repos;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;

namespace S2IndividualProjectDnDPrototype.Pages.NewCharacterPages
{   
    public class EditNewCharacterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int NewCharacterID { get; set; }

        [BindProperty]
        public NewCharacter? NewCharacter { get; set; }

        public IActionResult OnGet()
        {
            if (NewCharacterID <= 0)
            {
                return RedirectToPage("/Index");
            }

            NewCharacterService characterService = new NewCharacterService(new NewCharacterRepo());
            NewCharacter = characterService.GetNewCharacter(NewCharacterID.ToString());

            if (NewCharacter == null)
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

            if (NewCharacter == null || NewCharacter.Id <= 0)
            {
                return RedirectToPage("/Index");
            }

            NewCharacterService characterService = new NewCharacterService(new NewCharacterRepo());

            characterService.UpdateNewCharacter(NewCharacter);

            return RedirectToPage("/NewCharacterPages/NewCharacterPage", new { characterID = NewCharacter.Id });
        }
    }
}
