using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.ProjectUtilities
{
    public static class ExtensionMethods
    {
        public static bool HasValue(this string value)
        {
            if (value != string.Empty)
            {
                return true;
            }
            else if (value.Trim() != "")
            {
                return true;
            }
            else if (value == null)
            {
                return true;
            }
            else return false;
        }

        public static String StringRandom(this List<string> values)
        {
            string randomValue = string.Empty;
            Random rnd = new Random();
            int aux = values.Count;

            int value = rnd.Next(aux);
            return randomValue = values[value];
        } 
    }
}
