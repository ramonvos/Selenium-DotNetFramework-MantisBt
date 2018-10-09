using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Testes.Resources;
using AutomacaoMantisBT.Utilitarios.AssertsHelpers;
using AutomacaoMantisBT.Utilitarios.DependencyInjection;
using NUnit.Framework;
using Selenium.MapaCarreira.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.MapaCarreira.Testes.Tests
{
    [TestFixture, Order(6)]
    public class DeleteBugsTest : TestBase
    {

        [PageObject] LoginPage objLogin;
        [PageObject] DeleteBugSPage objdltBug;

        [Test, Description("Testa selecionar o primeiro bug da listagem, acionar o comando apagar e validar se o bug foi excluido.")]
        public void TEST_DeleteBugFromListSuccess()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objdltBug.OpenViewTask().DeleteBugFromList();


            ValidationResult.AssertElementContainsText(objdltBug.msgSucesso, MessagesDeleteBug.MensagemSucesso);

        }

        [Test, Description("Testa detalhar o primeiro bug da listagem, acionar o comando apagar e validar se o bug foi excluido.")]
        public void TEST_DeleteBugFromDetailsSuccess()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objdltBug.OpenViewTask().DeleteBugFromDetails();

            

            ValidationResult.AssertElementContainsText(objdltBug.msgSucesso, MessagesDeleteBug.MensagemSucesso);

        }

    }
}
