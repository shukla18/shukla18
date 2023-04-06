using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace POCTestingApp
{
    internal class RestClient
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Get(string url, string token)
        {
            string result = string.Empty;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://dog.ceo/api/breeds/image/random");
            result = await stringTask;

            Console.WriteLine(result);
        }
    }
}
