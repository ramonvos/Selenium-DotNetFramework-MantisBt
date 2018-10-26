using AutomacaoMantisBT.Utils.SeleniumBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class JavaScriptPopUpHelper
    {
        public static bool IsPopUpPresent()
        {
            try
            {
                WebdriverHooks.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopUpText()
        {
            if (!IsPopUpPresent())
                return "";
            return WebdriverHooks.Driver.SwitchTo().Alert().Text;
        }

        public static void ClickOkPopUp()
        {
            if (!IsPopUpPresent())
                return;
            WebdriverHooks.Driver.SwitchTo().Alert().Accept();
        }

        public static void ClickCancelPopUp()
        {
            if (!IsPopUpPresent())
                return;
            WebdriverHooks.Driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeysPopUp(string text)
        {
            if (!IsPopUpPresent())
                return;
            WebdriverHooks.Driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
