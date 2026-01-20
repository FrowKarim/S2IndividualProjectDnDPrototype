using LogicLayer.Entities;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class NewCharacterService
    {
        private INewCharacterRepo _NewCharacterRepo;
        public NewCharacterService(INewCharacterRepo _INewCharacterRepo)
        {
            _NewCharacterRepo = _INewCharacterRepo;
        }
        public NewCharacter GetNewCharacter(string NewCharacterID)
        {

            return _NewCharacterRepo.GetNewCharacter(NewCharacterID);
        }

        public void CreateNewCharacter(NewCharacter character)
        {

            _NewCharacterRepo.AddNewCharacter(character);
        }

        public NewCharacter UpdateNewCharacter(NewCharacter character)
        {
            return _NewCharacterRepo.UpdateNewCharacter(character);
        }
        public NewCharacter DeleteNewCharacter(NewCharacter character)
        {
            return _NewCharacterRepo.DeleteNewCharacter(character);
        }

        public List<NewCharacter> GetNewCharactersByCampaign(int campaignID)
        {
            return _NewCharacterRepo.GetNewCharactersByCampaign(campaignID);
        }


        public void ValidateAndFixNewCharacter(NewCharacter character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character), "NewCharacter cannot be null.");
            }

            FixStatPair(character, nameof(character.maxHealth), nameof(character.currentHealth), 1, 999);

            FixStatPair(character, nameof(character.maxStrength), nameof(character.currentStrength), 1, 100);

            FixStatPair(character, nameof(character.maxDexterity), nameof(character.currentDexterity), 1, 100);

            FixStatPair(character, nameof(character.maxWill), nameof(character.currentWill), 1, 100);

            FixStatPair(character, nameof(character.maxSpirit), nameof(character.currentSpirit), 1, 100);

            character.Armor = Math.Max(0, Math.Min(character.Armor, 100));
        }

        
        private void FixStatPair(NewCharacter character, string maxStatName, string currentStatName, int minValue, int maxValue)
        {
            var maxStatProp = typeof(NewCharacter).GetProperty(maxStatName);
            var currentStatProp = typeof(NewCharacter).GetProperty(currentStatName);

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
