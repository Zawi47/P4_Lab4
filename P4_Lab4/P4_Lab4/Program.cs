using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace P4_Lab4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            var stopwatch = new Stopwatch();
            /*
            var google = new RestClient("http://google.pl");
            var ath = new RestClient("http://ath.bielsko.pl");
            var wiki = new RestClient("http://pl.wikipedia.org");
            var zus = new RestClient("http://www.zus.pl");
            var gov = new RestClient("http://gov.pl");
            */
            var tasks = new List<Task>();
            stopwatch.Start();
            tasks.Add(Website.Download("http://google.pl", "/"));
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(Website.Download("http://ath.bielsko.pl", "/"));
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(Website.Download("http://pl.wikipedia.org", "/"));
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(Website.Download("http://ath.bielsko.pl", "/graficzne-formy-przekazu-informacji/"));
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(Website.Download("http://gov.pl", "/"));
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine("-----------");
            await Task.WhenAny(tasks);
            Console.WriteLine(stopwatch.Elapsed);
            await Task.WhenAll(tasks);
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Stop();
        }
    }
}
