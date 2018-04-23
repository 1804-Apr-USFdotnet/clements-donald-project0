using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace PalindromeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text to test for if it is a palindrome:");
            String input = Console.ReadLine();
            input = Parser.BL.StringCleaner.RemovePunctAndWhite(input);
            Console.WriteLine("Palindrome Test Results: "+ IsPalliComp.BL.IsPalli.PalliCheck(input));
            Console.ReadLine();
        }
    }
}
