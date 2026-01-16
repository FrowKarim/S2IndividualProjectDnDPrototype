using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Entities;
using LogicLayer.Services;
using DAL.Repos;
using static S2IndividualProjectDnDPrototype.Pages.LoginPageModel;


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

          

            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {

                return Page();
            }
            else if (role == "Player")
            {
                return RedirectToPage("/AccessDenied");
            }
            else
                return RedirectToPage("/LoginPage");


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
