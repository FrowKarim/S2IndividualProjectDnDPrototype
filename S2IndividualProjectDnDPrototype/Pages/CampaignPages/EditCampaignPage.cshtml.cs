using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using LogicLayer.Services;
using DAL.Repos;

namespace S2IndividualProjectDnDPrototype.Pages.CampaignPages
{
    public class EditCampaignPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CampaignID { get; set; }

        [BindProperty]
        public Campaign? Campaign { get; set; }
        public IActionResult OnGet()
        {

            if (CampaignID <= 0)
            {
                return RedirectToPage("/Index");
            }

            CampaignService characterService = new CampaignService(new CampaignRepo());
            Campaign = characterService.GetCampaign(CampaignID);

            if (Campaign == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();


        }

        public IActionResult OnPost()
        {

            if (Campaign == null || Campaign.Id <= 0)
            {
                return RedirectToPage("/Index");
            }

            CampaignService campaignService = new CampaignService(new CampaignRepo());

            campaignService.UpdateCampaign(Campaign);

            return RedirectToPage("/CampaignPages/CampaignList");

        }
    }
}
