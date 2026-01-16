using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S2IndividualProjectDnDPrototype.Pages.CampaignPages
{
    public class CampaignListModel : PageModel
    {
        public List<Campaign> Campaigns = new List<Campaign>();
        public void OnGet()
        {
            CampaignService cs = new CampaignService(new CampaignRepo());

            Campaigns = cs.GetAllCampaigns();
        }
    }
}
