using NUnit.Framework;
using OpenQA.Selenium;
using AutomacaoMantisBT.Utils.ExtentReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class ButtonHelper
    {
        public static void ClickButton(this IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);
            Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute());
            element.Click();




            //try
            //{
            //    if (SeleniumGetMethods.GetElement(element))
            //    {
            //        element.Click();
            //    }
            //    else { Reporter.AddTestInfo("Valor preenchido: Nulo/Vazio"); }

            //}
            //catch (NoSuchElementException ex)
            //{
            //    Reporter.FailTest(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "ERRO! Elemento esperado não apareceu." + "<pre>" + ex.Message + "</pre>", ex);
            //    Assert.IsTrue(false);
            //}


        }

        public static bool IsButtonEnabled(IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);
            return element.Enabled;
        }

        public static string GetButtonText(IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);

            if (element.GetAttribute("value") == null)
                return string.Empty;
            return element.GetAttribute("value");
        }
    }
}
