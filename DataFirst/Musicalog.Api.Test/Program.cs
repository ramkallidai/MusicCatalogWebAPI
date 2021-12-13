using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Api.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAlbum();
        }

        public async static void GetAlbum()
        {
            string APIUrl = "http://localhost:53877/api/album/getalbums";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync(APIUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }
                }
                catch (Exception ex)
                {

                }

                
            }
        }
    }
}
