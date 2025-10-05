using System;
using System.IO;
using System.Net;

namespace RealStateRentSystem_Buisness
{
    public static class CallerApi
    {
        private static string apiBaseUrl = "https://asp-home.com/api/mobile/";
        private static string secretKey = "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il";

        // ترجع معلومات المتصل الأساسية (Display)
        public static string GetDisplay(string phoneNumber)
        {
            string url = $"{apiBaseUrl}GetCallerInfo?secretKey={secretKey}&phoneNumber={phoneNumber}";
            return CallApi(url);
        }

        // ترجع معلومات تفصيلية (Exact)
        public static string GetExact(string phoneNumber)
        {
            string url = $"{apiBaseUrl}GetCallerDetails?secretKey={secretKey}&phoneNumber={phoneNumber}";
            return CallApi(url);
        }

        // دالة مشتركة لاستدعاء API
        private static string CallApi(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd(); // هترجع JSON أو نص
                }
            }
            catch (Exception ex)
            {
                return $"Error calling API: {ex.Message}";
            }
        }
    }
}
