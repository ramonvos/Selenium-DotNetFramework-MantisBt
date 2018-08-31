using Selenium.MapaCarreira2018.Utilitarios.ExtentReport;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.MapaCarreira2018.Utilitarios.SeleniumHelpers
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
