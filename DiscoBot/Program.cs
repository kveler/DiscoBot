using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace DiscoBot
{
    class Program
    {
        static void Main(string[] args)
        {

            GetRequest("http://www.google.nl");

            MyBot bot = new MyBot();

        }

        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://www.google.nl"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Console.WriteLine(mycontent);
                    }
                }

            }
        }
    }
}
