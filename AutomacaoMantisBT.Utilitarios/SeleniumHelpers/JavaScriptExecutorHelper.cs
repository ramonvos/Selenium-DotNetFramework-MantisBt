﻿using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utilitarios.SeleniumHelpers
{
    public static class JavaScriptExecutorHelper
    {
        public static void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)WebdriverHooks.Driver);

            executor.ExecuteScript(script);
        }

        public static void ExecuteAsyncJavaScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)WebdriverHooks.Driver);

            executor.ExecuteAsyncScript(script);
        }
    }
}
