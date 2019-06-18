using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace UI.Helpers
{
    public static class Extensions
    {
        public static string RemoveExtraWhiteSpace(this string str)
        {
            Regex regex = new Regex(@"\s+");
            return regex.Replace(str, " ");
        }
    }
}
