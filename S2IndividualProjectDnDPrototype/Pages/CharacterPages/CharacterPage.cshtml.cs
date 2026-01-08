using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S2IndividualProjectDnDPrototype.Pages.CharacterPages
{
    public class CharacterPageModel : PageModel
    {
        private Character _singleCharacter;

        public void OnGet(string characterID)
        {
            CharacterService characterService = new CharacterService(new CharacterRepo());
            _singleCharacter = characterService.GetCharacter(characterID);
        }

        public Character getSingleCharacter()
        {
            return _singleCharacter;
        }
    }
}
