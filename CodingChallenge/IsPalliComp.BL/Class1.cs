using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPalliComp.BL
{
    static public class IsPalli {
        public static bool PalliCheck(string str)
        {
            string orgnial = str.ToUpper();
            string reversed = IsPalliComp.BL.IsPalli.Reverse(orgnial);

            return orgnial == reversed;
        }

        public static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}

