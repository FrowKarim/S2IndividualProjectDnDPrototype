using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2IndividualProjectDnDPrototype.Helpers;
using DAL.Repos;
using LogicLayer.Entities;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class CharacterPageModel : PageModel
    {
        public void OnGet()
        {
            CharacterRepo conn = new CharacterRepo();
            string CharacterId = Request.Query["CharacterId"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);

        }

        public Character getSingleCharacter()
        {
            CharacterRepo conn = new CharacterRepo();
            string CharacterId = Request.Query["CharacterId"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);
            return SingleCharacter;
        }

    }
}
