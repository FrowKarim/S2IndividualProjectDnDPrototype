using LogicLayer.Entities;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class CampaignService
    {
        private ICampaignRepo _CampaignRepo;
        public CampaignService(ICampaignRepo _ICampaignRepo)
        {
            _CampaignRepo = _ICampaignRepo;
        }
        public Campaign GetCampaign(string CampaignID)
        {

            return _CampaignRepo.GetCampaign(CampaignID);
        }

        public void CreateCampaign(Campaign Campaign)
        {

            _CampaignRepo.AddCampaign(Campaign);
        }
        public Campaign DeleteCampaign(Campaign Campaign)
        {
            return _CampaignRepo.DeleteCampaign(Campaign);
        }
    }

}

