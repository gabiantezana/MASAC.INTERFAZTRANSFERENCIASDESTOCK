using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.HELPER
{
    public class ApiRestHelper
    {
        private static String Url { get; set; }
        private static String JsonRequest { get; set; }

        public ApiRestHelper(String url) { Url = url; }

        public static String MakeRequest(string requestUrl, String JSONRequest)
        {
            Url = requestUrl;
            JsonRequest = JSONRequest;

            Task<Task<Object>> t = new Task<Task<Object>>(HTTP_GET);
            t.Start();
            t.Wait();
            return t.Result.Result.ToString();
        }

        static async Task<Object> HTTP_GET()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                //Proxy = new WebProxy("http://localhost:8080"),
                UseProxy = true
            };

            Console.WriteLine("GET: + " + Url);

            // ... Use HttpClient.            
            HttpClient client = new HttpClient(handler);

            /*var byteArray = Encoding.ASCII.GetBytes("admin@nestle1:admin@nestle1");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));*/

            /*GET METHOD
            //HttpResponseMessage response = await client.GetAsync(Url);
            //HttpResponseMessage response = Task.Run(async () => { return await client.GetAsync(Url); }).Result;
            */

            var stringContent = new StringContent(JsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = Task.Run(async () => { return await client.PostAsync(Url, stringContent); }).Result;
            HttpContent content = response.Content;

            // ... Check Status Code                                
            Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

            // ... Read the string.

            //string result = await content.ReadAsStringAsync();
            string result = Task.Run(async () => { return await content.ReadAsStringAsync(); }).Result;

            return result?? String.Empty;
        }

    }
}
