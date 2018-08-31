using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.MapaCarreira.Testes.Base;
using Selenium.MapaCarreira2018.Selenium.PageObjectFactory;
using Selenium.MapaCarreira2018.Selenium.Pages;
using Selenium.MapaCarreira2018.Utilitarios.AssertsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.MapaCarreira.Testes.Tests
{   
    [TestFixture]
    public class LoginTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] HomePage objHome;

        [Test, Description("")]
        public void TEST_LoginSuccess()
        {
            objLogin.NavegarPaginaInicial().LogIn();
           
            ValidationResult.AssertElementDisplayed(objHome.btnFind);
        }

        [Test, Description("")]
        public void TEST_LoginInvalidUsername()
        {

        }

        [Test, Description("")]
        public void TEST_LoginInvalidPassword()
        {

        }

        [Test, Description("")]
        public void TEST_LoginUserRequired()
        {

        }

        [Test, Description("")]
        public void TEST_LoginUserEmpty()
        {

        }

        [Test, Description("")]
        public void TEST_LoginPasswordEmpty()
        {

        }

        [Test, Description("")]
        public void TEST_LoginUserAndPasswordEmpty()
        {

        }
    }
}
