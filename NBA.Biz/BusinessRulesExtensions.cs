using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Biz
{
    public static class BusinessRulesExtensions
    {
        public static string[] ExtractNames(this string names)
        {
            string[] tmpArr = names.Split(' ');
            string[] newArr = new string[4];

            if (tmpArr.Length < 3)
            {
                newArr[0] = tmpArr[0];
                newArr[2] = tmpArr[1].Trim(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            }
            else
            {
                newArr[0] = tmpArr[0];
                newArr[1] = tmpArr[1];
                newArr[2] = tmpArr[2].Trim(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            }
            newArr[3] = ExtractJerseyNumber(names);

            return newArr;

        }

        private static string ExtractJerseyNumber(string names)
        {
            string jerseyNumber = new string(names.Where(x => x >= '0' && x <= '9').ToArray());

            if (string.IsNullOrEmpty(jerseyNumber))
                jerseyNumber = "Not Available";

            return jerseyNumber;
        }

        public static string NumericCheck(this string value)
        {
            if(!IsNumeric(value))
            {
                value = "0";
            }
            return value;
        }

        private static bool IsNumeric(string value)
        {
            string[] nums = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            return nums.Any(value.Contains);
        }

        public static string RemoveLBs(this string variable)
        {
            return new string(variable.Where(x => x >= '0' && x <= '9').ToArray());
        }

        public static string RemoveCurrencySigns(this string currency, string unwantedChars)
        {
            char[] unwanted = unwantedChars.ToCharArray();
            string newStr = new string(currency.Where(c => !unwantedChars.Contains(c)).ToArray());

            if (string.IsNullOrEmpty(newStr))
            {
                return newStr = "0";
            }
            else
            {
                return newStr;
            }

        }


    }
}
