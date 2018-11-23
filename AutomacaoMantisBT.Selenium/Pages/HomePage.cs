using OpenQA.Selenium;
using AutomacaoMantisBT.Utils.SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utils.SeleniumHelpers;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class HomePage
    {
        public IWebElement containerPrincipal => WebdriverHooks.Driver.FindElement(By.Id("main-container"));


        public IWebElement menuMyView => WebdriverHooks.Driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[1]/a/span"));

        public IWebElement menuViewIssues => WebdriverHooks.Driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[1]/a/span"));

        public IWebElement menuManage => WebdriverHooks.Driver.FindElement(By.XPath("//*[@id='sidebar']/ul/li[7]/a/span"));

        public void ClickMenu(string menu)
        {

            switch (menu)
            {
                case "menuMyView":
                    menuMyView.ClickLink();
                    break;
                case "menuViewIssues":
                    menuViewIssues.ClickLink();
                    break;
                case "menuManage":
                    menuManage.ClickLink();
                    break;
            }
        }
    }
}
