using OpenQA.Selenium;
using AutomacaoMantisBT.Utilitarios.ExtentReport;
using System;
using System.Collections.Generic;
using System.Text;
using AutomacaoMantisBT.Utilitarios.ProjectUtilities;

namespace AutomacaoMantisBT.Utilitarios.SeleniumHelpers
{
    public static class TextBoxHelpers
    {
        public static void TypeInTextBox(this IWebElement element, string text)
        {
            SeleniumGetMethods.GetElement(element);
            if (text.HasValue())
            {
                element.SendKeys(text);
                Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor preenchido: " + text);
            }
            else Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor preenchido: [VAZIO]");


        }

        public static void ClearAndTypeInTextBox(this IWebElement element, string text)
        {
            SeleniumGetMethods.GetElement(element);
            element.Clear();
            element.SendKeys(text);
            Reporter.AddTestInfo(ProjectUtilities.Utilities.GetCurrentMethod() + " => " + "Elemento encontrado: " + element.GetElementAttribute() + " - Valor preenchido: " + text);
            
            

        }

        public static void ClearTextBox(this IWebElement element)
        {
            SeleniumGetMethods.GetElement(element);
            element.Clear();
        }
    }
}
