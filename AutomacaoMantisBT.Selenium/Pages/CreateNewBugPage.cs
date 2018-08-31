using OpenQA.Selenium;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using AutomacaoMantisBT.Utilitarios.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class CreateNewBugPage
    {   
        public const String url = "";
        public IWebElement linkMenuNewBug => WebdriverHooks.Driver.FindElement(By.LinkText(""));

        public IWebElement txtDescription => WebdriverHooks.Driver.FindElement(By.Id(""));

        public CreateNewBugPage CreateNewBug(String description)
        {
            NavigationHelper.NavigateToPage(url);

            txtDescription.TypeInTextBox(description);

            return new CreateNewBugPage();
        }

    }
}
