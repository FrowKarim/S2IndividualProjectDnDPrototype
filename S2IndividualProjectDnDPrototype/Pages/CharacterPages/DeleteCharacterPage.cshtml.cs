using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;
using LogicLayer.Services;
using LogicLayer.Interfaces;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages.CharacterPages
{
    public class DeleteCharacterPageModel : PageModel
    {
        [BindProperty]
        public Character Character { get; set; }
        private CharacterService CharacterService { get; set; }

        [BindProperty]
        public int CharacterID { get; set; }

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {
                CharacterService cs = new CharacterService(new CharacterRepo());
                string CharacterId = Request.Query["characterID"].ToString();
                Character getSingleCharacter = cs.GetCharacter(CharacterId);

                return Page();

            }
            else if (role == "Player")
            {
                return RedirectToPage("/AccessDenied");
            }
            else
                return RedirectToPage("/LoginPage");

        }

        public IActionResult OnPostDeleteCharacter()
        {
            CharacterService cs = new CharacterService(new CharacterRepo());
            string CharacterId = Request.Query["characterID"].ToString();
            Character characterToDelete = cs.GetCharacter(CharacterId);
            cs.DeleteCharacter(characterToDelete);
            return RedirectToPage("/CampaignPages/CampaignList");
        }


        public Character getSingleCharacter()
        {
            CharacterService cs = new CharacterService(new CharacterRepo());
            string CharacterId = Request.Query["characterID"].ToString();
            Character SingleCharacter = cs.GetCharacter(CharacterId);
            return SingleCharacter;
        }
    }
}
