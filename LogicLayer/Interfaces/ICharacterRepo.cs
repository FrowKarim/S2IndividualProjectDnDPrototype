using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface ICharacterRepo
    {
        List<Character> GetAllCharacters();
        Character GetCharacter(string CharacterID);
        Character AddCharacter(Character character);
        Character UpdateCharacter(Character Character);
        Character DeleteCharacter(Character Character);

        List<Character> GetCharactersByCampaign(int campaignID);
    }
}
