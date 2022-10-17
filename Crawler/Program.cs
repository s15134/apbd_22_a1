using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                string websiteUrl = args[0];
            

            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);

            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(html);

                foreach(var m in matches)
                {
                    Console.WriteLine(m.ToString());
                }
            }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("End");
        }
    }
}