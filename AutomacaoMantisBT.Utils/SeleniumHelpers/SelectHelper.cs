using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomacaoMantisBT.Utils.ExtentReport;
using AutomacaoMantisBT.Utils.ProjectUtilities;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class SelectHelper
    {
        public static void SelectText(this IWebElement element, string text)
        {
            SeleniumGetMethods.GetElement(element);
            if (text.HasValue())
            {   
                new SelectElement(element).SelectByText(text);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor selecionado: " + text);
            }
            else Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor selecionado: [NENHUM]");




        }
    }
}
