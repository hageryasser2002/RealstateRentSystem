using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class ApiManager
    {
        public static async Task<(string phoneNumber, string phoneType, string phoneName, string createdAt)> ImportCall(
        string importUrl, string phoneName, string secretKey)
        {
            string url = importUrl + "?secretKey=gfsh561r6hrtrty6eg3r1tger6tqweiukl1il&ddd=1";

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);

                    var response = await client.GetAsync(url);

                    string content = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"API Error: {response.StatusCode}, Content: {content}");
                        return (null, null, null, null);
                    }

                    dynamic result = JsonConvert.DeserializeObject(content);

                    if (result == null || result.error != null || result.message != null)
                    {
                        Console.WriteLine("API returned error or empty result.");
                        return (null, null, null, null);
                    }

                    return ((string)result.phoneNumber,
                            (string)result.phoneType,
                            (string)result.phoneName,
                            (string)result.createeAt);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}. The API might be down or internet is disconnected.");
                return (null, null, null, null);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"Timeout: {ex.Message}. The API did not respond in time.");
                return (null, null, null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return (null, null, null, null);
            }
        }


        public static bool ExportCall(string exportUrl, string phoneNumber, string phoneName, string numberType, string secretKey)
        {
            string url = string.Format("{0}?phoneNumber={1}&phoneName={2}&numberType={3}&secretKey={4}",
                                        exportUrl,
                                        Uri.EscapeDataString(phoneNumber),
                                        Uri.EscapeDataString(phoneName),
                                        Uri.EscapeDataString(numberType),
                                        Uri.EscapeDataString(secretKey));

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0"; // بعض السيرفرات تحتاج User-Agent

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException ex)
            {
                using (var sr = new StreamReader(ex.Response?.GetResponseStream() ?? Stream.Null))
                {
                    string serverMessage = sr.ReadToEnd();
                }
                return false;
            }
        }

    }
}

