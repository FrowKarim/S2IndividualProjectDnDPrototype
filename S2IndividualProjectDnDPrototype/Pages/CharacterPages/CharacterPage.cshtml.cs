using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Repos;
using LogicLayer.Entities;

namespace S2IndividualProjectDnDPrototype.Pages.CharacterPages
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
