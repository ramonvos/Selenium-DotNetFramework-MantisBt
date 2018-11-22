﻿using NUnit.Framework;

using AutomacaoMantisBT.Testes.Base;
using AutomacaoMantisBT.Utils.AssertsHelpers;
using AutomacaoMantisBT.Utils.DependencyInjection;
using AutomacaoMantisBT.Selenium.Pages;
using System.Configuration;
using AutomacaoMantisBT.Utils.ProjectUtilities;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture, Order(1)]
    public class LoginTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] HomePage objHome;



        [Test, Description("Testar realizar login informando dados validados e validar se foi exibido a página inicial")]
        public void TEST_LoginSuccess()
        {
            DatabaseConnection db = new DatabaseConnection();
            db.OpenConnection();
            string login = ConfigurationManager.AppSettings["USERNAME"];
            string senha = ConfigurationManager.AppSettings["PASSWORD"];


            objLogin.NavigateToLoginPage().LogIn(login, senha);

            ValidationResult.AssertElementDisplayed(objHome.containerPrincipal);
        }

        [Test, Description("Testa realizar login informando login e senha invalidos e validar se foi exibido mensagem de validação.")]
        public void TEST_LoginInvalidUsername()
        {
            objLogin.NavigateToLoginPage().LogIn("teste", "teste");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");
        }

        [Test, Description("Testa realizar login informando login invalido e validar se foi exibido mensagem de validação.")]
        public void TEST_LoginInvalidPassword()
        {
            objLogin.NavigateToLoginPage().LogIn("teste", "teste");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");
        }

        [Test, Description("Testa realizar login informando senha invalida e validar se foi exibido mensagem de validação.")]
        public void TEST_LoginUserRequired()
        {
            objLogin.NavigateToLoginPage().LogIn("", string.Empty);

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");
        }

        [Test, Description("Testa realizar login sem informar login e validar se foi exibido mensagem de validação.")]
        public void TEST_LoginUserEmpty()
        {
            objLogin.NavigateToLoginPage().LogIn("", string.Empty);

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");
        }

        [Test, Description("Testa realizar login sem informar senha e validar se foi exibido mensagem de validação.")]
        public void TEST_LoginPasswordEmpty()
        {
            objLogin.NavigateToLoginPage().LogIn("teste", "");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");
        }

        [Test, Description("Testa realizar login sem informar login e senha e validar se foi exibido mensagem de validação.")]
        public void TEST_LoginUserAndPasswordEmpty()
        {
            objLogin.NavigateToLoginPage().LogIn("", "");

            ValidationResult.AssertTextInElement(objLogin.msgErroLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");

        }

        [Test, Description("Testar realizar login informando dados validados e validar se foi exibido a página inicial")]
        
        public void TEST_LoginSuccessDataDriven()
        {

            objLogin.NavigateToLoginPage().LogInDataDriven("LogInTest");

            ValidationResult.AssertElementDisplayed(objHome.containerPrincipal);
        }

    }
}
