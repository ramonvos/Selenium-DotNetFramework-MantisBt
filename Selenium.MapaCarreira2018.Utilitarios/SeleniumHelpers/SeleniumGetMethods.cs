using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.MapaCarreira2018.Utilitarios.ExtentReport;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Text;


namespace Selenium.MapaCarreira2018.Utilitarios.SeleniumHelpers
{
    public static class SeleniumGetMethods
    {
        public static bool GetElement(IWebElement element)
        {
            try
            {
                if (element.Displayed || element.Enabled)
                {
                    try
                    {
                        Reporter.AddTestInfo(ProjectUtilities.Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetAttribute("id"));
                    }
                    catch { Reporter.AddTestInfo(ProjectUtilities.Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.ToString()); }

                }
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Reporter.AddTestInfo(ProjectUtilities.Utilitarios.GetCurrentMethod() + " => " + "ERRO! Elemento esperado não apareceu." + "<pre>" + ex.Message + "</pre>");
                Assert.IsTrue(false);
                return false;
            }

        }

        public static bool IsElementPresent(By locator)
        {
            
            try
            {
                return WebdriverHooks.Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

    }  
}
