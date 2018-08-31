using OpenQA.Selenium;
using AutomacaoMantisBT.Utilitarios.ExtentReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.SeleniumHelpers
{
    public static class TextBoxHelpers
    {
        public static void TypeInTextBox(this IWebElement element, string text)
        {
            SeleniumGetMethods.GetElement(element);
            element.SendKeys(text);
            Reporter.AddTestInfo("Valor preenchido: " + text);
        }

        public static void ClearTextBox(this IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);
            element.Clear();
        }
    }
}
