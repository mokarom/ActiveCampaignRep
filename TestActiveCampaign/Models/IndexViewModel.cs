using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestActiveCampaign.Models
{
    public class IndexViewModel
    {
        public string CampaignName { get; set; }
        public string ListName { get; set; }

        public int SelectedTemplate { get; set; }
        public SelectList Templates()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<string> temaplteNames = new List<string>();
            //Test
            foreach (var temaplteName in temaplteNames)
            {
                items.Add(new SelectListItem
                {
                    Value = "True",
                    Text = temaplteName,
                });
            }
            
            return new SelectList(items, "Value", "Text");
        }
        public static IndexViewModel CreateModel()
        {
            //ActiveCampaignHelper.GetCampaignList();
            ActiveCampaignHelper.CreateCampaign("single", "My Campaign From Code", "", 1, 1, "all", string.Empty);
            return new IndexViewModel();
        }
    }
}