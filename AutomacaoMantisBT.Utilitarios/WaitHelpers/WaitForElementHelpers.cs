using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomacaoMantisBT.Utilitarios.Exceptions;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.WaitHelpers
{
    public static class WaitForElementHelpers
    {
        static WebDriverWait wait;
        public static int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["DEFAULT_TIMEOUT"]);
        public static void WaitForElementDisplayed(By locator)
        {
            try
            {
                wait = new WebDriverWait(WebdriverHooks.Driver, TimeSpan.FromSeconds(timeout));
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail("{0} No Such Element.", ex);

            }

        }

        public static void WaitForElementClickable(By locator)
        {
            try
            {

                wait = new WebDriverWait(WebdriverHooks.Driver, TimeSpan.FromSeconds(timeout));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            }
            catch (NoSuchElementException ex)
            {

                Assert.Fail("{0} No Such Element.", ex);
            }
        }
        public static void WaitForElementClickable(IWebElement element)
        {
            try
            {
                wait = new WebDriverWait(WebdriverHooks.Driver, TimeSpan.FromSeconds(timeout));
                element = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (NoSuchElementException ex)
            {

                Assert.Fail("{0} No Such Element.", ex);
            }

        }
        public static void WaitForTextInElement(IWebElement element, string text)
        {
            try
            {
                wait = new WebDriverWait(WebdriverHooks.Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.TextToBePresentInElement(element,text));
            }
            catch (NoSuchElementException ex)
            {

                Assert.Fail("{0} No Such Element.", ex);
            }

        }
    }
}
