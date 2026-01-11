using LogicLayer.Entities;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class CharacterService 
    {
        private ICharacterRepo _CharacterRepo;
        public CharacterService(ICharacterRepo _ICharacterRepo)
        {
            _CharacterRepo = _ICharacterRepo;
        }
        public Character GetCharacter(string CharacterID)
        {

            return _CharacterRepo.GetCharacter(CharacterID);
        }

        public void CreateCharacter(Character character)
        {

             _CharacterRepo.AddCharacter(character);
        }

        public Character UpdateCharacter(Character character)
        {
            return _CharacterRepo.UpdateCharacter(character);
        }
        public Character DeleteCharacter(Character character)
        {
            return _CharacterRepo.DeleteCharacter(character);
        }

        public List<Character> GetCharactersByCampaign(int campaignID)
        {
            return _CharacterRepo.GetCharactersByCampaign(campaignID);
        }
    }
}
