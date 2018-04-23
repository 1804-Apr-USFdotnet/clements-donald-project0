using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.BL
{
    public static class StringCleaner
    {
        public static string RemovePunctAndWhite(string originalString)
        {
            var result = new String(originalString.Where
                  (ch => !Char.IsPunctuation(ch) && !Char.IsWhiteSpace(ch)).ToArray());
            return result;
        }
    }
}
