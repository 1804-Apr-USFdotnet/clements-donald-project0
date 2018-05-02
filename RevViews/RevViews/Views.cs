using System;
using System.Collections.Generic;
using System.Linq;
using RevViews.Models;
using static System.Console;

namespace RevViews
{
    internal class Views
    {
        internal static void MainMenuView()
        {
            int nav = -1;

            do
            {
                Clear();

                WriteLine("Main Menu:");
                WriteLine("  Menu Options:");
                WriteLine("    1: See the top 3 restaurants.");
                WriteLine("    2: Browse all restaurants.");
                WriteLine("    3: Search restaurants.");

                WriteLine("\nEnter -1 to exit application:\n");
                nav = MainOptionsViewRouter(Nav(3));
            } while (nav != -1);
        }

        private static int MainOptionsViewRouter(int nav)
        {
            switch (nav)
            {
                case 1:
                    nav = Top3View();
                    break;
                case 2:
                    nav = BrowseAllView();
                    break;
                case 3:
                    nav = SearchView();
                    break;
            }

            return nav;
        }

        private static int SearchView()
        {
            int nav;
            do
            {
                Clear();
                WriteLine("SearchView");
                Write("Enter Search: ");
                string userInput = ReadLine();
                var results = LittleWorker.Search(userInput).ToList();
                Clear();
                WriteLine("SearchView");
                WriteLine("  Results");

                List<int> trackID = new List<int>();
                for (var index = 0; index < results.Count(); index++)
                {
                    var e = results[index];

                    Console.WriteLine("    " + (index + 1) + ": " + e.RestaurantName);
                    trackID.Add(e.RestrauntID);
                }

                nav = Nav(results.Count());

                if (nav > 0)
                {
                    nav = Details(trackID[nav - 1]);
                }
            } while (nav > 0);

            return nav;
        }

        private static int BrowseAllView()
        {
            int nav = 0;
            List<Restraunt> restraunts = LittleWorker.GetAllRestaurants().ToList();
            do
            {
                do
                {
                    Clear();

                    List<int> trackID = new List<int>();
                    for (var index = 0; index < restraunts.Count(); index++)
                    {
                        var e = restraunts[index];

                        Console.WriteLine("   " + (index + 1) + ": " + e.RestaurantName);
                        trackID.Add(e.RestrauntID);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine((restraunts.Count+1)+" for sort options or selection for details.");


                    nav = Nav(restraunts.Count()+1);
                    if (nav > 0 && nav < (restraunts.Count + 1))
                    {
                        nav = Details(trackID[nav-1]);
                    }
                } while (nav > 0 && nav < (restraunts.Count+1));

                if (nav == restraunts.Count + 1)
                {
                    Console.WriteLine("Sort alpha asc 1, alpha dec 2, low ratings first 3, top ratings first 4.");
                    nav = Nav(4);
                    Console.WriteLine("You picked sort option :" + nav);
                    restraunts = LittleWorker.SortRestraunts(ref restraunts, nav);
                }

                if(nav == 0)
                    break;
            } while (nav != -1);

            return nav;
        }


        private static int Top3View()
        {
            int nav = 0;
            do

            {
                Clear();
                WriteLine("Top Thee");
                WriteLine("  Results");
                List<int> rank = LittleWorker.ViewTop();

                nav = Nav(3);

                if (nav > 0)
                    nav = Details(rank[nav - 1]);
            } while (nav > 0);

            return nav;
        }

        private static int Nav(int upperLimit)
        {
            Write("Enter selection: ");
            int.TryParse(ReadLine(), out int nav);
            do
            {
                if (nav <= upperLimit && nav >= -1)
                {
                    return nav;
                }
                else
                {
                    WriteLine("INVALID INPUT! Current valid options are intergers between -1 and " + upperLimit);
                    int.TryParse(ReadLine(), out int newNav);
                    nav = newNav;
                }
            } while (!(nav <= upperLimit && nav >= -1));

            return 0;
        }

        public static int Details(int id)
        {
            Clear();
            var r = LittleWorker.GetRestaurant(id);
            WriteLine("Details:");
            WriteLine("\tName:\t\t" + r.RestaurantName);
            WriteLine("\tLocation:\t" + r.AddressLineOne);
            WriteLine("\t \t \t" + r.City + " " + r.StateCode + " " + r.PostalCode);
            WriteLine();
            WriteLine("\tPhone:\t\t" + r.Phone);
            WriteLine("\tWebsite:\t" + r.Website);
            WriteLine("\tRating:\t\t" + LittleWorker.Rating(id));
            WriteLine();
            WriteLine("Enter 1 to see reviews, -1 to exit app, or 0 to return to the main menu.");
            int nav = Nav(1);
            if (nav == 1)
            {
                ListReviews(id);
                ReadLine();
            }

            return nav;
        }

        public static void ListReviews(int id)
        {
            var r = LittleWorker.GetReviews(id);
            foreach (var review in r)
            {
                Console.WriteLine("Username:\t" + review.Username);
                Console.WriteLine("Rating:\t" + review.Rating);
                Console.WriteLine("Headline:\t" + review.Headline);
                Console.WriteLine("Review:\t" + review.Body);
                WriteLine();
            }
        }
    }
}