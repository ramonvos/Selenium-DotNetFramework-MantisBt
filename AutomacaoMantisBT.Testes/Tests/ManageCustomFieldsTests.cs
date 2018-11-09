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
    [TestFixture, Order(11)]
    public class ManageCustomFieldsTests : TestBase
    {
        [PageObject] LoginPage objLogin;

        [Test, Description("")]
        public void TEST_ManageCustomFieldsCreateNewCustomField()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageCustomFieldsEdit()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }

        [Test, Description("")]
        public void TEST_ManageCustomFieldsDelete()
        {
            objLogin.NavigateToLoginPage().LogIn();

        }
    }
}
