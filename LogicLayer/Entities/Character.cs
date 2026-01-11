using LogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
    public class Character
    {
        public int Id { get; set; }

        [AllowNull]
        public User user { get; set; }

        
        public int UserId { get; set; }

        public int CampaignId { get; set; }

        
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

        public Character()
        {

        }






    }
}
