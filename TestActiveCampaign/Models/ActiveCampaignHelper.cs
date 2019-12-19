using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestActiveCampaign.Helpers;

namespace TestActiveCampaign.Models
{
    public class ActiveCampaignHelper
    {
        private const string BaseUrl = "https://ufd1573384312.api-us1.com/";
        private const string ActiveCampaignApiKey = "d5ac76be10df57acf7d9e92396bcf7b24ee82fb7f71ecd73c313469d6e0442179ed5057b";


        public static void GetCampaignList()
        {
            ThirdPartyApiHelper thirdPartyApiHelper = new ThirdPartyApiHelper(ActiveCampaignApiKey, string.Empty, BaseUrl);
            string subUrl = "/admin/api.php";
            string query = "?api_action=campaign_list&api_key=" + ActiveCampaignApiKey + "&api_output=json&filters[type]=single&full=0&page=1";
            var json = thirdPartyApiHelper.MakeApiRequest(subUrl + query, EnumRequestType.GET);
            //dynamic listObject = JObject.Parse(json);
            //string listId = listObject.id.ToString();
        }

        public static void CreateCampaign(string type, string name, string sDate, int status, int visibility, string trackLinks, string listIds)
        {
            ThirdPartyApiHelper thirdPartyApiHelper = new ThirdPartyApiHelper(ActiveCampaignApiKey, string.Empty, BaseUrl);
            string subUrl = "/admin/api.php";
            string query = "?api_action=campaign_create&api_key=" + ActiveCampaignApiKey + "";
            
            var data = new Dictionary<string, string>();
            data.Add("type", "single");
            data.Add("name", "This is a test campaign from Code 1");
            data.Add("sdate", "2019-11-11 08:40:00");
            data.Add("status", "1");
            data.Add("public", "1");
            data.Add("p[1]", "1");
            data.Add("p[2]", "2");
            data.Add("m[5]", "100");

            var json = thirdPartyApiHelper.MakeApiRequestFormData(subUrl + query, EnumRequestType.POST, data);
        }
    }
}