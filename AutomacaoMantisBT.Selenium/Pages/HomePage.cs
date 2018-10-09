using OpenQA.Selenium;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class HomePage
    {
        public IWebElement containerPrincipal => WebdriverHooks.Driver.FindElement(By.Id("main-container"));
    }
}
