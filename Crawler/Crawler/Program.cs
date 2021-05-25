using System;

namespace NewsProject.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Sender sender = new Sender();
            TSNNewsCrawler tSNNewsCrawler = new TSNNewsCrawler();
            foreach (var i in tSNNewsCrawler.Crawl(DateTime.Now))
            {
                sender.Send(i); Console.WriteLine(i.Url);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
