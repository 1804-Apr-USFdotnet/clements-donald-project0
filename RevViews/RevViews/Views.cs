using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using RevViews.BLL;
using RevViews.Models;

namespace RevViews
{
   internal class Views
    {
        internal static void MainMenuView()
        {
            string keyInput = "";

            do
            {
                Clear();
                WriteLine("Your selection was: " + keyInput + "\n");

                WriteLine("Main Menu:");
                WriteLine("  Menu Options:");
                WriteLine("    1: See the top 3 restaurants.");
                WriteLine("    2: Browse all restaurants.");
                WriteLine("    3: Search restaurants.");

                WriteLine("\nPress x to exit application:\n");
                keyInput = ReadKey().Key.ToString().ToUpper();
                keyInput = MainOptionsViewRouter(keyInput);

            } while (keyInput != "X");
        }

        private static string MainOptionsViewRouter(string keyInput)
        {
            string result = keyInput;
            switch (result)
            {
                case "D1":
                    Top3View();
                    result = "1";
                    break;
                case "D2":
                    BrowseAllView();
                    result = "2";
                    break;
                case "D3":
                    SearchView();
                    result = "3";
                    break;
                case "X":
                    result = "X";
                    break;
                default:
                    result = "INVALID";
                    break;
            }

            return result;
        }

        private static void SearchView()
        {
            Clear();
            WriteLine("Displaying SearchView");
            Write("Enter Search: ");
            string input = ReadLine();
            var results = LittleWorker.Search(input);
            Clear();
            foreach (var restraunt in results)
            {
                Console.WriteLine(restraunt.RestrauntID + ": " + restraunt.RestaurantName);
            }
            Write("Enter number for more details: ");
            ReadLine();

        }

        private static void BrowseAllView()
        {
            Clear();
            var restraunts = LittleWorker.ShowAll();
            foreach (var restraunt in restraunts)
            {
                Console.WriteLine(restraunt.RestrauntID +": "+ restraunt.RestaurantName);
            }
                
            
            Write("Enter number for more details: ");
            int input = Int32.Parse(ReadLine());
        }

        private static void Top3View()
        {
            Clear();
            WriteLine("Displaying Top3View");
            LittleWorker.ViewTop();
            Write("Enter number for more details: ");
            ReadLine();
        }


    }
}
