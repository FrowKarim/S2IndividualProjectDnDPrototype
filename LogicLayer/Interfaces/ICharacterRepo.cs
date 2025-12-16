using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    internal interface ICharacterRepo
    {
        List<Character> GetAllCharacters();
        Character GetCharacter(string CharacterID);
        void AddCharacter(Character character);
        void UpdateCharacter(Character Character);
        void DeleteCharacter(Character Character);
    }
}
