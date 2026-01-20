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
    public class CreateNewCharacterModel : PageModel
    {
        [BindProperty]
        public NewCharacter NewCharacter { get; set; }
        private NewCharacterService NewCharacterService { get; set; }
        public IActionResult OnGet()
        {
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
            //{
            //    return Page();
            //}

            NewCharacterService characterService = new NewCharacterService(new NewCharacterRepo());
            //NewCharacter.CampaignId = HttpContext.Session.GetInt32(nameof(AccountCampaignID)) ?? 0;
            //NewCharacter.UserId = HttpContext.Session.GetInt32(nameof(AccountUserID)) ?? 0;
            NewCharacter.UserId = 2;
            characterService.CreateNewCharacter(NewCharacter);
            
            return RedirectToPage("/Index");
        }

    }
}
