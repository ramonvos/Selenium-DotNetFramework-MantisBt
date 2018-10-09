using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.SeleniumHelpers
{
    public static class WindowsHelper
    {
        public static string GetTitle()
        {
            return WebdriverHooks.Driver.Title;
        }
    }
}
