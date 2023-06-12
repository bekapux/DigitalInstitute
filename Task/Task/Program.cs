﻿using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, decimal> CompanyPrice = new Dictionary<string, decimal>();
            Advertisement advertiser1 = new Advertisement("Google ", 12000);
            Advertisement advertiser2 = new Advertisement("Microsoft", 20000);
            Advertisement advertiser3 = new Advertisement("Amazon", 10000);
            Advertisement advertiser4 = new Advertisement("Apple", 70000);
            Advertisement advertiser5 = new Advertisement("Meta", 800);

            CompanyPrice.Add(advertiser1.Advertiser, advertiser1.Price);
            CompanyPrice.Add(advertiser2.Advertiser, advertiser2.Price);
            CompanyPrice.Add(advertiser3.Advertiser, advertiser3.Price);
            CompanyPrice.Add(advertiser4.Advertiser, advertiser4.Price);
            CompanyPrice.Add(advertiser5.Advertiser, advertiser5.Price);

            RandomAd(CompanyPrice);

        
        }

        public static string RandomAd<TKey>(IDictionary<TKey, decimal> dictionary)
        {
            throw new ArgumentException();
        }

        public class Advertisement 
        {
            public string Advertiser { get;set; }
            public decimal Price { get; set; } // 

            //Dictionary<string, decimal> CompanyPrice = new Dictionary<string, decimal>();

            public Advertisement(string advertiser, decimal price)
            {
                Advertiser = advertiser;
                Price = price;
                //CompanyPrice.Add(advertiser, price);
            }

            public override string ToString()
            {
                return $"Ad of {Advertiser}";
            }

        }

    }

    // Assume you have a website where there are two advertising slots.
    // With every refresh of the website, different advertisements will appear in these two slots.
    // For instance, upon the first refresh, there might be ads for Facebook and Google.
    // On the second refresh, there may be ads for Apple and Microsoft, and so forth.
    // The frequency at which an ad appears is proportional to the amount paid by the advertiser;
    // for example, if Microsoft pays $10,000 and Apple pays $15, Microsoft's ads will appear more often.
    // Now onto the task:
    // You are required to write a method that will randomly return two ads from a dictionary.
    // The likelihood of an ad being returned should be based on the price the advertiser has paid for it.
}