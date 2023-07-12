using System;

namespace task22
{
    class Program
    {
        static void Main(string[] args)
        {
            var adsDictionary = new Dictionary<Advertiser, List<Ad>>
    {
        {
            new Advertiser { Name = "Facebook", Price = 10000 },
            new List<Ad>
            {
                new Ad { Name = "Ad1" },
                new Ad { Name = "Ad2" }
            }
        },
        {
            new Advertiser { Name = "Google", Price = 8000 },
            new List<Ad>
            {
                new Ad { Name = "Ad3" },
                new Ad { Name = "Ad4" }
            }
        },

    };


            var selectedAds = GetRandomAds(adsDictionary);

            // Display the selected ads
            foreach (var ad in selectedAds)
            {
                Console.WriteLine(ad.Name);
            }
        }
        public class Advertiser
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        public class Ad
        {
            public string Name { get; set; }
        }
        public List<Ad> GetRandomAds(Dictionary<Advertiser, List<Ad>> adsDictionary)
        {
            List<Ad> selectAds = new List<Ad>();

            decimal totalPrice = adsDictionary.Keys.Sum(advertiser => advertiser.Price);

            decimal randomValue = (decimal)new Random().NextDouble() * totalPrice;

            foreach (var entry in adsDictionary)
            {
                var advertiser = entry.Key;
                var ads = entry.Value;

                if (randomValue <= advertiser.Price)
                {
                    selectAds.Add(ads[new Random().Next(ads.Count)]);
                }
                randomValue -= advertiser.Price;
            }
            return selectAds;
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
