using DAL.Repos;
using LogicLayer.Entities;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace S2IndividualProjectDnDPrototype.Pages.CampaignPages
{
    public class CampaignDetailsModel : PageModel
    {
        public Campaign Campaign { get; set; }
        private CampaignService CampaignService { get; set; }

        [BindProperty]
        public int CampaignID { get; set; }

        public void OnGet()
        {
            CampaignID = Convert.ToInt32(Request.Query["campaignID"]);
        }

        public Campaign getSingleCampaign()
        {
            CampaignService cs = new CampaignService(new CampaignRepo());
            Campaign SingleCampaign = cs.GetCampaign(CampaignID);

            return SingleCampaign;
        }
    }
}
