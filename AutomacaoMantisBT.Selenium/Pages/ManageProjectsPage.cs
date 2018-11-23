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
    public class ManageProjectsPage
    {
        public IWebElement linkManageProjects => WebdriverHooks.Driver.FindElement(By.LinkText("Manage Projects"));
        public By btnNewProjectLocator => By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div/form/fieldset/button");
        public IWebElement btnNewProject => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div/form/fieldset/button"));

        public By txtProjectNameLocator => By.Id("project-name");
        public IWebElement txtProjectName => WebdriverHooks.Driver.FindElement(By.Id("project-name"));
        public IWebElement ddlProjectStatus => WebdriverHooks.Driver.FindElement(By.Id("project-status"));
        public IWebElement ddlState => WebdriverHooks.Driver.FindElement(By.Id("project-view-state"));
        public IWebElement txtDescriptiomn => WebdriverHooks.Driver.FindElement(By.Id("project-description"));

        public IWebElement msgSucesso => WebdriverHooks.Driver.FindElement(By.CssSelector("div.alert.alert-success.center"));
        public IWebElement msgErro => WebdriverHooks.Driver.FindElement(By.CssSelector("div.alert.alert-danger"));

        public By msgWarningLocator => By.CssSelector("div.alert.alert-warning.center");


        public IWebElement btnSaveProject => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Add Project']"));

        public IWebElement btnUpdateProject => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Update Project']"));

        public IWebElement btnDeleteProject => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Delete Project']"));

        public IWebElement linkFirstProjectToList => WebdriverHooks.Driver.FindElement(By.XPath("//td/a"));
        public By linkFirstProjectToListLocator => By.XPath("//td/a");

        public IWebElement linkSecondProjectToList => WebdriverHooks.Driver.FindElement(By.XPath("//tr[2]/td/a"));

        public ManageProjectsPage CreateNewProject(string name, string status, string visibility, string description)
        {
            linkManageProjects.ClickLink();

            WaitForElementHelpers.WaitForElementDisplayed(btnNewProjectLocator);
            btnNewProject.ClickButton();
            WaitForElementHelpers.WaitForElementDisplayed(txtProjectNameLocator);
            txtProjectName.TypeInTextBox(name);
            ddlProjectStatus.SelectText(status);
            ddlState.SelectText(visibility);
            txtDescriptiomn.TypeInTextBox(description);


            return new ManageProjectsPage();
        }


        public ManageProjectsPage UpdateProject()
        {
            linkManageProjects.ClickLink();
            WaitForElementHelpers.WaitForElementDisplayed(btnNewProjectLocator);
            linkFirstProjectToList.ClickLink();
            btnUpdateProject.ClickButton();
            return new ManageProjectsPage();
        }


        public ManageProjectsPage DeleteProject()
        {
            linkManageProjects.ClickLink();
            WaitForElementHelpers.WaitForElementDisplayed(btnNewProjectLocator);
            linkSecondProjectToList.ClickLink();
            btnDeleteProject.ClickButton();
            WaitForElementHelpers.WaitForElementDisplayed(msgWarningLocator);
            btnDeleteProject.ClickButton();
            return new ManageProjectsPage();
        }

        public ManageProjectsPage SaveNewProject()
        {
            btnSaveProject.ClickButton();
            return new ManageProjectsPage();
        }
    }
}
