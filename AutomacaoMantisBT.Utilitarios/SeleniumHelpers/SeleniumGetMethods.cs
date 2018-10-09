using NUnit.Framework;
using OpenQA.Selenium;
using AutomacaoMantisBT.Utilitarios.ExtentReport;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Text;


namespace AutomacaoMantisBT.Utilitarios.SeleniumHelpers
{
    public static class SeleniumGetMethods
    {
        public static bool GetElement(IWebElement element)
        {
            try
            {   

                if (element.Displayed || element.Enabled)
                {
                    return true;
                    //try
                    //{
                    //    Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute());
                    //}
                    //catch { Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.ToString()); }

                }return false;
               
            }
            catch (NoSuchElementException ex)
            {
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "ERRO! Elemento esperado não apareceu." + "<pre>" + ex.Message + "</pre>");
                Reporter.TestException(ex);
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
