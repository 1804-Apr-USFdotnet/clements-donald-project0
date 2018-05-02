using System;
using System.Collections.Generic;
using System.Linq;
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
                    nav = SearchView();;
                    break;
            }

            return nav;
        }

        private static int SearchView()
        {
            Clear();
            WriteLine("SearchView");
            Write("Enter Search: ");
            string userInput = ReadLine();
            var results = LittleWorker.Search(userInput).ToList();
            Clear();
            WriteLine("SearchView");
            WriteLine("  Results");

            for (var index = 0; index < results.Count(); index++)
            {
                var e = results[index];

                Console.WriteLine("    "+(index+1)+ ": " + e.RestaurantName);
            }

            int nav = Nav(results.Count());

            return nav;
        }

        private static int BrowseAllView()
        {
            int nav = 0;
            Clear();
            var restraunts = LittleWorker.GetAllRestaurants();
            foreach (var restraunt in restraunts)
            {
                Console.WriteLine(restraunt.RestrauntID +": "+ restraunt.RestaurantName);
            }
                
            
            
            nav = Nav(restraunts.Count());

            return nav;

        }

        private static int Top3View()
        {
            int nav = 0;
            Clear();
            WriteLine("Top Thee");
            WriteLine("  Results");
            List<int> rank = LittleWorker.ViewTop();

            nav = Nav(3);

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
    }
}
