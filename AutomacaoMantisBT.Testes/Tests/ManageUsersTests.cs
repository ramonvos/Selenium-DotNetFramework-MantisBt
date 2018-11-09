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
    [TestFixture, Order(8)]
    public class ManageUsersTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        
        [Test, Description("")]
        public void TEST_ManageUsersCreateNewAccount()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageUsersUpdateUser()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageUsersResetPassword()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageUsersDeleteUser()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }
    }
}
