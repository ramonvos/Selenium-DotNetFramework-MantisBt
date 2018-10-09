using NUnit.Framework;

using Selenium.MapaCarreira.Testes.Base;
using AutomacaoMantisBT.Utilitarios.AssertsHelpers;
using AutomacaoMantisBT.Utilitarios.DependencyInjection;
using AutomacaoMantisBT.Selenium.Pages;
using System.Configuration;

namespace Selenium.MapaCarreira.Testes.Tests
{
    [TestFixture, Order(1)]
    public class LoginTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] HomePage objHome;



        [Test, Description("")]
        public void TEST_LoginSuccess()
        {
            string login = ConfigurationManager.AppSettings["USERNAME"];
            string senha = ConfigurationManager.AppSettings["PASSWORD"];


            objLogin.NavegarPaginaLogin().LogIn(login, senha);

            ValidationResult.AssertElementDisplayed(objHome.containerPrincipal);
        }

        [Test, Description("")]
        public void TEST_LoginInvalidUsername()
        {
            objLogin.NavegarPaginaLogin().LogIn("teste", "teste");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.");
        }

        [Test, Description("")]
        public void TEST_LoginInvalidPassword()
        {
            objLogin.NavegarPaginaLogin().LogIn("teste", "teste");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.");
        }

        [Test, Description("")]
        public void TEST_LoginUserRequired()
        {
            objLogin.NavegarPaginaLogin().LogIn("", string.Empty);

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.");
        }

        [Test, Description("")]
        public void TEST_LoginUserEmpty()
        {
            objLogin.NavegarPaginaLogin().LogIn("", string.Empty);

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.");
        }

        [Test, Description("")]
        public void TEST_LoginPasswordEmpty()
        {
            objLogin.NavegarPaginaLogin().LogIn("teste", "");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.");
        }

        [Test, Description("")]
        public void TEST_LoginUserAndPasswordEmpty()
        {
            objLogin.NavegarPaginaLogin().LogIn("", "");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.");

        }
    }
}
