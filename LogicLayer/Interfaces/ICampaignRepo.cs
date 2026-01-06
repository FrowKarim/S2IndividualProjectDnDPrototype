using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface ICampaignRepo
    {
        List<Campaign> GetAllCampaigns();
        Campaign GetCampaign(int CampaignID);
        Campaign AddCampaign(Campaign Campaign);
        void UpdateCampaign(Campaign Campaign);
        Campaign DeleteCampaign(Campaign Campaign);
    }
}
