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


        public void ValidateAndFixCharacter(Character character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character), "Character cannot be null.");
            }

            FixStatPair(character, nameof(character.maxHealth), nameof(character.currentHealth), 1, 999);

            FixStatPair(character, nameof(character.maxStrength), nameof(character.currentStrength), 1, 100);

            FixStatPair(character, nameof(character.maxDexterity), nameof(character.currentDexterity), 1, 100);

            FixStatPair(character, nameof(character.maxWill), nameof(character.currentWill), 1, 100);

            FixStatPair(character, nameof(character.maxSpirit), nameof(character.currentSpirit), 1, 100);

            character.Armor = Math.Max(0, Math.Min(character.Armor, 100));
        }

        
        private void FixStatPair(Character character, string maxStatName, string currentStatName, int minValue, int maxValue)
        {
            var maxStatProp = typeof(Character).GetProperty(maxStatName);
            var currentStatProp = typeof(Character).GetProperty(currentStatName);

            if (maxStatProp == null || currentStatProp == null)
                throw new ArgumentException("Invalid property names for stat pair.");

            int maxStat = (int)maxStatProp.GetValue(character);
            int currentStat = (int)currentStatProp.GetValue(character);

            // Fix max stat: clamp between minValue and maxValue
            maxStat = Math.Max(minValue, Math.Min(maxStat, maxValue));

            // Fix current stat: clamp between 0 and maxStat
            currentStat = Math.Max(0, Math.Min(currentStat, maxStat));

            maxStatProp.SetValue(character, maxStat);
            currentStatProp.SetValue(character, currentStat);
        }
    }
}
