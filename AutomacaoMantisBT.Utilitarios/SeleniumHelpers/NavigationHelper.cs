using AutomacaoMantisBT.Utilitarios.ExtentReport;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.SeleniumHelpers
{
    public static class NavigationHelper
    {   
        public static void NavigateToPage(string url)
        {
            try
            {
                WebdriverHooks.Driver.Navigate().GoToUrl(url);
                Reporter.AddTestInfo("Acessando a página: " + url);
            }
            catch
            {


            }
        }
    }
}
