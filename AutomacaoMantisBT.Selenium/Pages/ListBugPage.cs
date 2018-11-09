using AutomacaoMantisBT.Utils.ProjectUtilities;
using AutomacaoMantisBT.Utils.SeleniumBase;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using AutomacaoMantisBT.Utils.WaitHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class ListBugPage
    {
        public static string selectBug = string.Empty;
        private By gridIssues = By.Id("buglist");

        
        public IWebElement linkViewIssues => WebdriverHooks.Driver.FindElement(By.LinkText("View Issues"));

        public IWebElement linkBugDetails => WebdriverHooks.Driver.FindElement(By.XPath("//table[@id='buglist']/tbody/tr/td[4]"));

        public IWebElement bugId => WebdriverHooks.Driver.FindElement(By.CssSelector("td.bug-id"));

        public String GetLinkTextBug()
        {
            WaitForElementHelpers.WaitForElementDisplayed(gridIssues);

            return linkBugDetails.Text;
        }

        // Get all number link all bugs first page
        public List<string> GetNumberAllBugs()
        {
            List<string> bugs = new List<string>();
            int aux = CountBugList();

            for (int i = 1; i < aux; i++)
            {   
                string bugNumber = WebdriverHooks.Driver.FindElement(By.XPath("//table[@id='buglist']/tbody/tr["+i+"]/td[4]")).Text;
                bugs.Add(bugNumber);
            }

            return bugs;

        }


        public int CountBugList()
        {
            return WebdriverHooks.Driver.FindElements(By.XPath("//table[@id='buglist']/tbody/tr")).Count;
        }

        public void ClickIssueDetails()
        {
            linkViewIssues.ClickLink();

            string linkBug = GetLinkTextBug();

            List<String> allBugs = GetNumberAllBugs();
            selectBug = allBugs.StringRandom();

            WebdriverHooks.Driver.FindElement(By.LinkText(selectBug)).ClickLink();

            int bugNumber = Convert.ToInt32(selectBug);
        }

    }
}
