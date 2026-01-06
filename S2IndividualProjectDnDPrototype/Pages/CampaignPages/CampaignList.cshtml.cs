using LogicLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages.CampaignPages
{
    public class CampaignListModel : PageModel
    {
        public List<Campaign> Campaigns = new List<Campaign>();
        public void OnGet()
        {
            CampaignRepo conn = new CampaignRepo();

            Campaigns = conn.GetAllCampaigns();
        }
    }
}
