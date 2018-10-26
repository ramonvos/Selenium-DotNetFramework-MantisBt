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
    }
}
