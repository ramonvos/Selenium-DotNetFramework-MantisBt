using OpenQA.Selenium;
using Selenium.MapaCarreira2018.Utilitarios.ExtentReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.MapaCarreira2018.Utilitarios.SeleniumHelpers
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
