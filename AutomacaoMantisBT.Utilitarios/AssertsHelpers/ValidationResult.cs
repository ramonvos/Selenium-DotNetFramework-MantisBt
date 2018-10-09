using NUnit.Framework;
using OpenQA.Selenium;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using AutomacaoMantisBT.Utilitarios.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using AutomacaoMantisBT.Utilitarios.ExtentReport;

namespace AutomacaoMantisBT.Utilitarios.AssertsHelpers
{
    public static class ValidationResult
    {   

        public static void AssertElementDisplayed(IWebElement element)
        {
            try
            {
                if (SeleniumGetMethods.GetElement(element))
                {
                    Assert.That(element.Displayed);
                    Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute());
                }
                
            }
            catch (Exception ex)
            {
                Assert.Fail("{0} Element no displayed", ex);
                
            }
        }

        public static void AssertElementDisplayed(By locator)
        {
            try
            {
                Assert.That(WebdriverHooks.Driver.FindElement(locator).Displayed);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + locator);
            }
            catch (Exception ex)
            {
                Assert.Fail("{0} Element no displayed", ex);

            }
        }

        public static void AssertTextInElement(IWebElement element, string text)
        {
            try
            {
                Assert.That(element.Text == text);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor: "+ text);
            }
            catch (Exception ex)
            {
                Assert.Fail("{0} Text at element NOT EQUAL", ex);

            }
        }

        public static void AssertElementContainsText(IWebElement element, string text)
        {
            try
            {
                Assert.That(element.Text.Contains(text));
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor: " + text);
            }
            catch (Exception ex)
            {
                Assert.Fail("{0} Text at element NOT CONTAINS expected text", ex);

            }
        }

        public static void AssertValueInElement(IWebElement element, string value)
        {
            try
            {
                Assert.That(element.GetAttribute("value") == value);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute());
            }
            catch (Exception ex)
            {
                Assert.Fail("{0} Value at element NOT EQUAL", ex);

            }
        }

        public static void AssertElementNotPresent(By locator)
        {
            
            try
            {
                Assert.False(WebdriverHooks.Driver.FindElement(locator).Displayed);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + locator);
            }
            catch (Exception ex)
            {
                Assert.Fail("{0} Element displayed", ex);

            }
        }

    }
}
