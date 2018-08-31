using OpenQA.Selenium;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.MapaCarreira2018.Selenium.Pages
{
    public class HomePage
    {
        public IWebElement btnFind => WebdriverHooks.Driver.FindElement(By.Name("commit"));
    }
}
