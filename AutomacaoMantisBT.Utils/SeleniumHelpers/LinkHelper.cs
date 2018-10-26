using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class LinkHelper
    {
        private static IWebElement element;

        public static void ClickLink(this IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);
            element.Click();
        }
    }
}
