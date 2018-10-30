using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace OptionsChain
{
    class Program
    {
        static void Main(string[] args)
        {
            var callList = new List<string>();

            Console.WriteLine("Ticker?");
            string ticker = Console.ReadLine();
            string url = $"https://finance.yahoo.com/quote/{ticker}/options/";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            HtmlNode node = doc.DocumentNode.SelectSingleNode(doc.GetElementbyId("Col1-1-OptionContracts-Proxy").XPath + " /section/section[1]/div[2]/div/table");

            foreach (var newNode in node.Descendants())
            {
                if (newNode.InnerText.Length > 3)
                {
                    if (newNode.HasClass("data-col0") == true)
                    {
                        Console.WriteLine(newNode.InnerText);
                        Console.ReadLine();
                        Console.WriteLine();
                        callList.Add(newNode.InnerText);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
