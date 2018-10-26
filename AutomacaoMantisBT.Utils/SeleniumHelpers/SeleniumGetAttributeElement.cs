using AutomacaoMantisBT.Utils.ProjectUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoMantisBT.Utils.SeleniumHelpers
{
    public static class SeleniumGetAttributeElement
    {   
        public static string GetElementAttribute(this IWebElement element)
        {
            string attribute = string.Empty;
            try
            {
                if (element.GetAttribute("id").HasValue())
                {
                    attribute = element.GetAttribute("id");
                    return attribute;
                }
            }
            catch { }
            try
            {
                if (element.GetAttribute("name").HasValue())
                {
                    attribute = element.GetAttribute("name");
                    if (attribute != null)
                    {
                        return attribute;
                    }
                    
                }
            }
            catch { }

            try
            {
                if (element.GetAttribute("value").HasValue())
                {
                    attribute = element.GetAttribute("value");
                    if (attribute != null)
                    {
                        return attribute;
                    }
                }
            }
            catch { }
            try
            {
                if (element.GetAttribute("class").HasValue())
                {
                    attribute = element.GetAttribute("class");
                    return attribute;
                }
            }
            catch { }
            return "Elemento não identificado";
            

        }
    }
}
