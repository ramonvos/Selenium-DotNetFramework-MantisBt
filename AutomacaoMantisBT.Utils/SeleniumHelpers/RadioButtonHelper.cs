using AutomacaoMantisBT.Utils.ExtentReport;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class RadioButtonHelper
    {   
        public static void RadioButtonSelect(this IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);
            Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute());

            element.Click();
        }
    }
}
