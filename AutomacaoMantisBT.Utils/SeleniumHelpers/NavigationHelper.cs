using AutomacaoMantisBT.Utils.ExtentReport;
using AutomacaoMantisBT.Utils.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class NavigationHelper
    {   
        public static void NavigateToPage(string url)
        {
            try
            {
                WebdriverHooks.Driver.Navigate().GoToUrl(url);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " +"Acessando a página: " + url);
            }
            catch
            {


            }
        }
    }
}
