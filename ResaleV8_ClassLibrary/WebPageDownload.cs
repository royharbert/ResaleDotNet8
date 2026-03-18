using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace ResaleV8_ClassLibrary
{
    public class WebPageDownload
    {
        public static async Task WebDownload(/*string[] args*/)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://poshmark.com/closet/magic_finds112"; // Replace with the desired URL
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(responseBody); // Outputs the raw HTML content
                    File.WriteAllText(@"C:\ResaleDB\WebDownload", responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}

