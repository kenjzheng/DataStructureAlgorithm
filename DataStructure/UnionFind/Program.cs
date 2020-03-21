using System;
using System.Collections.Generic;
using Common;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            var travelCosts = GetTravleCost();
            travelCosts.Sort();

            var cities = GetCities(travelCosts);
            var unionFind = new UnionFind<City>(cities);

            travelCosts.ForEach(x =>
            {
                if (!unionFind.Connected(x.EndPointA, x.EndPointB))
                {
                    unionFind.Union(x.EndPointA, x.EndPointB);
                }
            });

            //find cheapest route from Toronto to Guangzhou
            var toronto = new City("Toronto");
            var guangzhou = new City("Guangzhou");

            //to be continue

            Console.ReadLine();
        }

        private static List<TravleCost> GetTravleCost()
        {
            var travleCosts = new List<TravleCost>();
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("Vancouver"), 600));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("Beijing"), 700));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("Shanghai"), 800));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("New York"), 500));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("Guangzhou"), 1600));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("London"), 500));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("Pairs"), 500));
            travleCosts.Add(new TravleCost(new City("Toronto"), new City("Frankfurt"), 550));

            //travleCosts.Add(new TravleCost(new City("Vancouver"), new City("Tokyo"), 1000));
            //travleCosts.Add(new TravleCost(new City("Vancouver"), new City("Hongkong"), 1100));

            //travleCosts.Add(new TravleCost(new City("Tokyo"), new City("Hongkong"), 700));
            //travleCosts.Add(new TravleCost(new City("Tokyo"), new City("Beijing"), 700));
            //travleCosts.Add(new TravleCost(new City("Tokyo"), new City("Shanghai"), 500));

            travleCosts.Add(new TravleCost(new City("Hongkong"), new City("Guangzhou"), 100));
            travleCosts.Add(new TravleCost(new City("Hongkong"), new City("Beijing"), 400));
            //travleCosts.Add(new TravleCost(new City("Hongkong"), new City("Shanghai"), 300));


            //travleCosts.Add(new TravleCost(new City("New York"), new City("Beijing"), 1100));
            //travleCosts.Add(new TravleCost(new City("New York"), new City("London"), 700));
            //travleCosts.Add(new TravleCost(new City("New York"), new City("Vancouver"), 300));
            //travleCosts.Add(new TravleCost(new City("New York"), new City("Pairs"), 700));
            //travleCosts.Add(new TravleCost(new City("New York"), new City("Frankfurt"), 700));
            //travleCosts.Add(new TravleCost(new City("New York"), new City("San Francisco"), 700));

            //travleCosts.Add(new TravleCost(new City("San Francisco"), new City("Sydney"), 800));
            //travleCosts.Add(new TravleCost(new City("San Francisco"), new City("Vancouver"), 100));
            //travleCosts.Add(new TravleCost(new City("San Francisco"), new City("Tokyo"), 800));
            //travleCosts.Add(new TravleCost(new City("San Francisco"), new City("Hongkong"), 400));

            //travleCosts.Add(new TravleCost(new City("Sydney"), new City("Guangzhou"), 600));
            //travleCosts.Add(new TravleCost(new City("Sydney"), new City("Hongkong"), 300));

            //travleCosts.Add(new TravleCost(new City("London"), new City("Guangzhou"), 800));
            //travleCosts.Add(new TravleCost(new City("London"), new City("Pairs"), 100));

            //travleCosts.Add(new TravleCost(new City("Pairs"), new City("Shanghai"), 700));
            //travleCosts.Add(new TravleCost(new City("Pairs"), new City("Beijing"), 700));

            //travleCosts.Add(new TravleCost(new City("Frankfurt"), new City("London"), 200));
            //travleCosts.Add(new TravleCost(new City("Frankfurt"), new City("Pairs"), 200));
            //travleCosts.Add(new TravleCost(new City("Frankfurt"), new City("Beijing"), 600));
            //travleCosts.Add(new TravleCost(new City("Frankfurt"), new City("Shanghai"), 600));

            //travleCosts.Add(new TravleCost(new City("Shanghai"), new City("Guangzhou"), 200));
            travleCosts.Add(new TravleCost(new City("Beijing"), new City("Guangzhou"), 300));
            //travleCosts.Add(new TravleCost(new City("Beijing"), new City("Shanghai"), 100));

            return travleCosts;
        }

        private static List<City> GetCities(List<TravleCost> costs)
        {
            Dictionary<string, City> dic = new Dictionary<string, City>();

            costs.ForEach(x =>
            {
                if (!dic.ContainsKey(x.EndPointA.CityName))
                {
                    dic.Add(x.EndPointA.CityName, x.EndPointA);
                }

                if (!dic.ContainsKey(x.EndPointB.CityName))
                {
                    dic.Add(x.EndPointB.CityName, x.EndPointB);
                }
            });

            return new List<City>(dic.Values);
        }
    }
}
