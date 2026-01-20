using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;
using LogicLayer.Services;
using LogicLayer.Interfaces;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages.NewCharacterPages
{
    public class DeleteNewCharacterPageModel : PageModel
    {
        [BindProperty]
        public NewCharacter NewCharacter { get; set; }
        private NewCharacterService NewCharacterService { get; set; }

        [BindProperty]
        public int NewCharacterID { get; set; }

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {
                NewCharacterService cs = new NewCharacterService(new NewCharacterRepo());
                string NewCharacterId = Request.Query["characterID"].ToString();
                NewCharacter getSingleNewCharacter = cs.GetNewCharacter(NewCharacterId);

                return Page();

            }
            else if (role == "Player")
            {
                return RedirectToPage("/AccessDenied");
            }
            else
                return RedirectToPage("/LoginPage");

        }

        public IActionResult OnPostDeleteNewCharacter()
        {
            NewCharacterService cs = new NewCharacterService(new NewCharacterRepo());
            string NewCharacterId = Request.Query["characterID"].ToString();
            NewCharacter characterToDelete = cs.GetNewCharacter(NewCharacterId);
            cs.DeleteNewCharacter(characterToDelete);
            return RedirectToPage("/CampaignPages/CampaignList");
        }


        public NewCharacter getSingleNewCharacter()
        {
            NewCharacterService cs = new NewCharacterService(new NewCharacterRepo());
            string NewCharacterId = Request.Query["characterID"].ToString();
            NewCharacter SingleNewCharacter = cs.GetNewCharacter(NewCharacterId);
            return SingleNewCharacter;
        }
    }
}
