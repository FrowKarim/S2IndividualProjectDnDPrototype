using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using DAL;
using Microsoft.AspNetCore.Http;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;
using LogicLayer.Services;
using LogicLayer.Interfaces;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages.CampaignPages
{
    public class DeleteCampaignPageModel : PageModel
    {
        [BindProperty]
        public Campaign Campaign { get; set; }
        private CampaignService CampaignService { get; set; }

        [BindProperty]
        public int CampaignID { get; set; }

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {
                CampaignRepo conn = new CampaignRepo();
                string CampaignId = Request.Query["CampaignID"].ToString();
                Campaign getSingleCampaign = conn.GetCampaign(Convert.ToInt32(CampaignId));

                return Page();

            }
            else if (role == "Player")
            {
                return RedirectToPage("/Index");
            }
            else
                return RedirectToPage("/LoginPage");

        }

        public IActionResult OnPostDeleteCampaign()
        {
            CampaignService cs = new CampaignService(new CampaignRepo());
            Campaign campaignToDelete = cs.GetCampaign(CampaignID);
            cs.DeleteCampaign(campaignToDelete);
            return RedirectToPage("/CampaignPages/CampaignList");
        }


        public Campaign getSingleCampaign()
        {
            CampaignRepo conn = new CampaignRepo();
            string CampaignId = Request.Query["CampaignID"].ToString();
            Campaign SingleCampaign = conn.GetCampaign(Convert.ToInt32(CampaignId));
            return SingleCampaign;
        }
    }
}
