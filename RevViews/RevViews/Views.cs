using System;
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
                    Top3View();
                    break;
                case 2:
                    BrowseAllView();
                    break;
                case 3:
                    SearchView();;
                    break;
            }

            return nav;
        }

        private static void SearchView()
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

            Nav(results.Count());
        }

        private static void BrowseAllView()
        {
            Clear();
            var restraunts = LittleWorker.ShowAll();
            foreach (var restraunt in restraunts)
            {
                Console.WriteLine(restraunt.RestrauntID +": "+ restraunt.RestaurantName);
            }
                
            
            
            var nav = Nav();
        }

        private static void Top3View()
        {
            Clear();
            WriteLine("Displaying Top3View");
            LittleWorker.ViewTop();

        }

        public static int Nav()
        {
            int.TryParse(ReadLine(), out int nav);
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
