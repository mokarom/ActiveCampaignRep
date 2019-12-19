using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace TestActiveCampaign.Helpers
{
    public class ThirdPartyApiHelper
    {
        private string AuthorizationKeyOrToken { get; set; }
        private string Secret { get; set; }
        private string BaseUrl { get; set; }

        public ThirdPartyApiHelper(string authorizationKeyOrToken, string secret, string baseUrl)
        {
            AuthorizationKeyOrToken = authorizationKeyOrToken;
            Secret = secret;
            BaseUrl = baseUrl;
        }

        public string MakeApiRequest(string subUrl, EnumRequestType requestType, string jsonToPost = "")
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                string url = BaseUrl + subUrl;
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Accept", "application/json");
                    //webClient.Headers.Add("Authorization", "bearer " + AuthorizationKeyOrToken);
                    //webClient.UseDefaultCredentials = true;
                    if (!string.IsNullOrEmpty(jsonToPost))
                    {
                        webClient.Headers.Add("Content-Type:application/x-www-form-urlencoded");
                        return webClient.UploadString(url, requestType.ToString(), jsonToPost);
                    }
                    else
                    {
                        return webClient.DownloadString(url);
                    }
                }
            }
            catch (Exception exception)
            {
                //LogHelper.LogException(exception);
            }

            return string.Empty;
        }

        public string MakeApiRequestFormData(string subUrl, EnumRequestType requestType, Dictionary<string, string> data)
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                string url = BaseUrl + subUrl;
                var client = new HttpClient();
                var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(data) };
                var res = client.SendAsync(req);
            }
            catch (Exception exception)
            {
                //LogHelper.LogException(exception);
            }

            return string.Empty;
        }
    }

    public enum EnumRequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}