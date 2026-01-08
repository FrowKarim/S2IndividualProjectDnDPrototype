using DAL.Repos;
using LogicLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S2IndividualProjectDnDPrototype.Pages.CharacterPages
{
    public class DeleteCharacterPageModel : PageModel
    {
        public void OnGet()
        {
            CharacterRepo conn = new CharacterRepo();
            string CharacterId = Request.Query["CharacterId"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);
        }
    

        public IActionResult OnPost()
        {
            CharacterRepo conn = new CharacterRepo();
            string CharacterId = Request.Query["characterID"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);
            conn.DeleteCharacter(SingleCharacter);
            return RedirectToPage("/Index");
        }


        public Character getSingleCharacter()
        {
            CharacterRepo conn = new CharacterRepo();
            string CharacterId = Request.Query["character"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);
            return SingleCharacter;
        }
    } }
