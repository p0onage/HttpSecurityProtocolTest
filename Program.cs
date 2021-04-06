using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleHttpTest
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            while (true)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                       | SecurityProtocolType.Tls11
                                                       | SecurityProtocolType.Tls12
                                                       | SecurityProtocolType.Ssl3;

                Console.WriteLine("Security Protocols : " + ServicePointManager.SecurityProtocol);

                try
                {

                    Console.WriteLine("Press 0 to test TLS 1.0 ");
                    Console.WriteLine("Press 1 to test TLS 1.1 ");
                    Console.WriteLine("Press 2 to test TLS 1.2 ");
                    Console.WriteLine("Press 3 to test external site");
                    const string tlsSite0 = "https://tls-v1-0.badssl.com:1010/";
                    const string tlsSite1 = "https://tls-v1-1.badssl.com:1011/";
                    const string tlsSite2 = "https://tls-v1-0.badssl.com:1010/";

                    var key = int.Parse(Console.ReadLine());

                    HttpResponseMessage response;

                    if (key == 0)
                    {
                        response = await client.GetAsync(tlsSite0);
                    }
                    else if (key == 1)
                    {
                        response = await client.GetAsync(tlsSite1);
                    }
                    else if (key == 2)
                    {
                        response = await client.GetAsync(tlsSite2);
                    }
                    else
                    {
                        var siteUrl = Console.ReadLine();
                        response = await client.GetAsync(siteUrl);
                    }

                    //response.EnsureSuccessStatusCode();
                    Console.WriteLine("Status Code " + response.StatusCode);
                    Console.WriteLine();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine($"SecurityProtocol {ServicePointManager.SecurityProtocol} was accepted. {responseBody}");
                    Console.WriteLine();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught! TLS Not supported.");
                    Console.WriteLine("Message :{0} ", e.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}