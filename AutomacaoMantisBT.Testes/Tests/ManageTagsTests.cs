using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Utils.DependencyInjection;
using NUnit.Framework;
using AutomacaoMantisBT.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture, Order(10)]
    public class ManageTagsTests : TestBase
    {
        [PageObject] LoginPage objLogin;

        [Test, Description("")]
        public void TEST_ManageUsersCreateNewTag()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageUsersUpdateTag()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageUsersDelete()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

    }
}
