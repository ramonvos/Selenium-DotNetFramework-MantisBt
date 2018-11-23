using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Testes.Base;
using AutomacaoMantisBT.Utils.AssertsHelpers;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture, Order(9)]
    public class ManageProjectsTests : TestBase
    {
        [PageObject]
        LoginPage objLogin;
        [PageObject]
        HomePage objHome;
        [PageObject]
        ManageProjectsPage objProjects;

        string menuManage = "menuManage";

        [Test]
        public void TEST_ManageProjectsCreateNewProject()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objProjects.CreateNewProject("Project " + Guid.NewGuid(), "development", "public", "project Description").SaveNewProject(); ;

            ValidationResult.AssertElementContainsText(objProjects.msgSucesso, "Operation successful.");
        }

        [Test]
        public void TEST_ManageProjectsCreateNewProjectAlreadyExists()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objProjects.CreateNewProject("teste", "development", "public", "project Description").SaveNewProject(); ;

            ValidationResult.AssertElementContainsText(objProjects.msgErro, "A project with that name already exists. Please go back and enter a different name.");
        }

        [Test]
        public void TEST_ManageProjectsEditExistingProject()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);

            objProjects.UpdateProject();

            ValidationResult.AssertElementDisplayed(objProjects.linkFirstProjectToListLocator);

        }


        [Test]
        public void TEST_ManageProjectsAddSubProject()
        {

            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);

            objProjects.UpdateProject();

            ValidationResult.AssertElementDisplayed(objProjects.linkFirstProjectToListLocator);

        }

        [Test]
        public void TEST_ManageProjectsDeleteProject()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objHome.ClickMenu(menuManage);
            objProjects.DeleteProject();

            ValidationResult.AssertElementDisplayed(objProjects.linkFirstProjectToListLocator);

        }
    }
}
