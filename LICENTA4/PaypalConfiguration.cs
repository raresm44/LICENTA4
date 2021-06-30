using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace LICENTA4
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AeRcxkEA2PNzlYcSDo0X7rIE8l5IjhbpTD-uV2iOSbee9JADZa33jndLrG1gxEwc1e55xIg5Y8nqvRhY";
            clientSecret = "EDhlpM5S5bvJwqPE69YJIpRWH3J_2UUPnDXNUw2svSSG2bQBNJQ1Q8x15jMGAUxBUTU4fNgy2jeBkNQS";
        }

        private static Dictionary<string, string> getconfig()
        { 
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetApiContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = getconfig();
            return apiContext;
        }
    }
}