using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface INewCharacterRepo
    {
        List<NewCharacter> GetAllNewCharacters();
        NewCharacter GetNewCharacter(string NewCharacterID);
        NewCharacter AddNewCharacter(NewCharacter character);
        NewCharacter UpdateNewCharacter(NewCharacter NewCharacter);
        NewCharacter DeleteNewCharacter(NewCharacter NewCharacter);

        List<NewCharacter> GetNewCharactersByCampaign(int campaignID);
    }
}
