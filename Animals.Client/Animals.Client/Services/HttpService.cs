using System;
using System.Net.Http;
using System.Threading.Tasks;
using Animals.Share;
using Newtonsoft.Json;

namespace Animals.Client.Services
{
    public class HttpService
    {
        public static async Task<BodyResponseFormatBase<T>> GetAsync<T>(string url)
        {
            return await SendAsync<T>(url, HttpMethod.Get);
        }

        private static async Task<BodyResponseFormatBase<T>> SendAsync<T>(string url, HttpMethod method, HttpContent content=null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            
            if (content != null)
                request.Content = content;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.SendAsync(request);
                string body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BodyResponseFormatBase<T>>(body);
            }
        }

        internal Task SendAsync(string v, HttpMethod get)
        {
            throw new NotImplementedException();
        }
    }
       
            
    
}
