using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;
using LogicLayer.Services;
using LogicLayer.Interfaces;
using DAL.Repos;


namespace S2IndividualProjectDnDPrototype.Pages
{
    public class CreateCharacterModel : PageModel
    {
        [BindProperty]
        public Character Character { get; set; }
        private CharacterService CharacterService { get; set; }
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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            CharacterService characterService = new CharacterService(new CharacterRepo());
            //Character.CampaignId = HttpContext.Session.GetInt32(nameof(AccountCampaignID)) ?? 0;
            //Character.UserId = HttpContext.Session.GetInt32(nameof(AccountUserID)) ?? 0;
            Character.UserId = 2;
            characterService.CreateCharacter(Character);
            
            return RedirectToPage("/Index");
        }

    }
}
