using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Utility
{
    public static class Extensions
    {
        public static string RemoveLBs(this string variable)
        {
            return new string(variable.Where(x => x >= '0' && x <= '9').ToArray());
        }

        public static string RemoveCurrencySigns(this string currency,string unwantedChars)
        {
            char[] unwanted = unwantedChars.ToCharArray();
            string newStr = new string(currency.Where(c => !unwantedChars.Contains(c)).ToArray());
            return newStr;
        }

        public static string CheckNULLS(this string field)
        {
            if(string.IsNullOrEmpty(field))
            {
                return field = string.Empty;
            }
            return field;
        }

        public static string ExtractWin(this string home)
        {
            string win = home;

            if (home.Contains('-'))
            {
                win = home.Substring(0, home.IndexOf('-'));
            }
            return win;
        }

        public static string ExtractLoss(this string home)
        {
            string loss = home;

            if (home.Contains('-'))
            {
                loss = home.Substring(home.IndexOf('-') + 1, home.Length - home.IndexOf('-')-1);
            }
            return loss;
        }
    }
}
