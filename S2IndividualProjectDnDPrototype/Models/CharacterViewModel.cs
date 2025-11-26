using System.Diagnostics.CodeAnalysis;
using DAL.Models;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Models
{
    public class CharacterViewModel
    {
        public int Id { get; set; }
        public UserViewModel user { get; set; }
        
        public int UserId { get; set; }

        public int CampaignId { get; set; }

        [AllowNull]
        public string Name { get; set; }


        public int maxHealth { get; set; }
        public int currentHealth { get; set; }

        public int maxStrength { get; set; }
        public int currentStrength { get; set; }

        public int maxDexterity { get; set; }
        public int currentDexterity { get; set; }

        public int maxWill { get; set; }
        public int currentWill { get; set; }

        public int maxSpirit { get; set; }
        public int currentSpirit { get; set; }

        public int Armor { get; set; }

        [AllowNull]
        public string LeftHand { get; set; }

        [AllowNull]
        public string RightHand { get; set; }

        [AllowNull]
        public string Body1 { get; set; }

        [AllowNull]
        public string Body2 { get; set; }

        [AllowNull]
        public string Backpack1 { get; set; }

        [AllowNull]
        public string Backpack2 { get; set; }

        [AllowNull]
        public string Backpack3 { get; set; }

        [AllowNull]
        public string Backpack4 { get; set; }

        [AllowNull]
        public string Backpack5 { get; set; }

        [AllowNull]
        public string Backpack6 { get; set; }

        [AllowNull]
        public string Notes { get; set; }

        public CharacterViewModel()
        {

        }






    }
}
