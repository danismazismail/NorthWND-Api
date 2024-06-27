using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Common
{
    public static class StringExtensions
    {
        public static Dictionary<string, bool> IsInCode(this string s,string value)
        {
            List<string> keywords = new List<string> { "if", "else", "for", "foreach", "while", "switch", "case", "do", "try", "catch", "finally" };

            Dictionary<string, bool> result = new Dictionary<string, bool>();

            foreach (string keyword in keywords)
            {
                result[keyword] = value.Contains(keyword);
            }

            return result;

        }

        public static bool IsInAlphaNumericCharacter(this string s)
        {
            char[] alphaNumericCharacters = new char[] { '?', '!', '&', '%' };
                        
            foreach (char item in alphaNumericCharacters)
            {
                if (s.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
