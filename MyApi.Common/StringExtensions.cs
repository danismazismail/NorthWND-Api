using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Common
{
    public static class StringExtensions
    {
        public static bool IsInCode(this string s,string value)
        {
            //value değişken içinde kod var mı ?
            //içinde kod yok.
            return false;
        
        }

        public static bool IsInAlphaNumericCharacter(this string s, string value)
        {
            //value değişken içinde AlphaNumericCharacter var mı ?
            //AlphaNumericCharacter= ?!&%
            //içinde kod yok.
            return false;
        }
    }
}
