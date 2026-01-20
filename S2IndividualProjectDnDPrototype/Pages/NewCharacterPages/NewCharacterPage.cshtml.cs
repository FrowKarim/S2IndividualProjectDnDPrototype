using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S2IndividualProjectDnDPrototype.Pages.NewCharacterPages
{
    public class NewCharacterPageModel : PageModel
    {
        private NewCharacter _singleNewCharacter;

        public void OnGet(string characterID)
        {
            NewCharacterService characterService = new NewCharacterService(new NewCharacterRepo());
            _singleNewCharacter = characterService.GetNewCharacter(characterID);
        }

        public NewCharacter getSingleNewCharacter()
        {
            return _singleNewCharacter;
        }
    }
}
