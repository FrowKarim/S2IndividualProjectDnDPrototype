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
    public class CreateCampaignModel : PageModel
    {
        [BindProperty]
        public Campaign Campaign { get; set; }
        private CampaignService CampaignService { get; set; }
        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString(AdminSessionKey);
            if (role == "DungeonMaster")
            {

                return Page();
            }
            else if (role == "Player")
            {
                return RedirectToPage("/Index");
            }
            else
                return RedirectToPage("/LoginPage");

        }
        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            CampaignService campaignService = new CampaignService(new CampaignRepo());
            campaignService.CreateCampaign(Campaign);
            return RedirectToPage("/CampaignPages/CampaignList");
        }
    }
}
