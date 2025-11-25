using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2IndividualProjectDnDPrototype.Helpers;
using S2IndividualProjectDnDPrototype.Models;

namespace S2IndividualProjectDnDPrototype.Pages
{
    public class CharacterPageModel : PageModel
    {
        public void OnGet()
        {
            CharacterDataConnector conn = new CharacterDataConnector();
            string CharacterId = Request.Query["CharacterId"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);

        }

        public Character getSingleCharacter()
        {
            CharacterDataConnector conn = new CharacterDataConnector();
            string CharacterId = Request.Query["CharacterId"].ToString();
            Character SingleCharacter = conn.GetCharacter(CharacterId);
            return SingleCharacter;
        }

    }
}
