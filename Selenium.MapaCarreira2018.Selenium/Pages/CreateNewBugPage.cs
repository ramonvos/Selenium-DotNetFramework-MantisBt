using OpenQA.Selenium;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumBase;
using Selenium.MapaCarreira2018.Utilitarios.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.MapaCarreira2018.Selenium.Pages
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
