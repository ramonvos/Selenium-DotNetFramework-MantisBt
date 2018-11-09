using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using Selenium.MapaCarreira.Testes.Base;
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
        [PageObject] LoginPage objLogin;

        [Test, Description("")]
        public void TEST_ManageProjectsCreateNewProject()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageProjectsEditExistingProject()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageProjectsAddSubProject()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageProjectsDeleteProject()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }
    }
}
