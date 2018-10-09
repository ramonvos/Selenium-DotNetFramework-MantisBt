using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.ProjectUtilities
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
