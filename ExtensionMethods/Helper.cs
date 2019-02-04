using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class Helper
    {
        public static bool IsEven(this int main)
        {
            return main % 2 == 0;
        }
        public static bool IsDevidedBy(this int main,int target)
        {
            return main % target == 0;
        }
        public static string ConvertToString(this ICollection collection)
        {
            string res = "";
            foreach (var item in collection)
            {
                res += item.ToString();
            }
            return res;
        }
    }
}
