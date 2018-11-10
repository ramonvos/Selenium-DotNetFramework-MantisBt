using NUnit.Framework;
using Selenium.MapaCarreira.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utils.AssertsHelpers;
using AutomacaoMantisBT.Utils.DependencyInjection;
using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Testes.TestData;
using AutomacaoMantisBT.Utils.SeleniumBase;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using AutomacaoMantisBT.Testes.Resources;
using AutomacaoMantisBT.Utils.WaitHelpers;

namespace AutomacaoMantisBT.Testes.Tests
{
    [TestFixture,Order(2)]
    public class CreateNewBugTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] CreateNewBugPage objNewBug;

        [Test, Description("Testar cadastrar novo bug informando todos os campos no formulário e validar se a mensagem de sucesso foi exibida.")]
        public void TEST_CreateNewBugAllFieldsSuccess()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objNewBug.OpenNewBugPage().CreateNewBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, true,"plataforma","SO","VErsao so",TestDataConfig.atribuir, TestDataConfig.resumo, TestDataConfig.descricao, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, true, true).saveNewBug();

            WaitForElementHelpers.WaitForElementDisplayed(objNewBug.msgSucessoLocator);
            ValidationResult.AssertTextInElement(objNewBug.msgSucesso, MessagesNewBug.MensagemSucesso);

        }

        [Test, Description("Testa cadastrar novo bug informando apenas os campos obrigatórios e e validar se a mensagem de sucesso foi exibida.")]
        public void TEST_CreateNewBugRequiredFieldsSuccess()
        {
            objLogin.NavigateToLoginPage().LogIn();
            objNewBug.OpenNewBugPage().CreateNewBug(String.Empty, String.Empty, String.Empty, String.Empty, false, String.Empty, String.Empty, String.Empty, String.Empty, TestDataConfig.resumo, TestDataConfig.descricao, String.Empty, String.Empty, false, false).saveNewBug();

            ValidationResult.AssertTextInElement(objNewBug.msgSucesso, MessagesNewBug.MensagemSucesso);

        }

        [Test, Description("Testa tentar prosseguir sem exibir o campo Resumo e validar se a mensagem de obrigatoriedade foi exibida.")]
        public void TEST_CreateNewBugSummaryRequired()
        {


            objLogin.NavigateToLoginPage().LogIn();
            objNewBug.OpenNewBugPage().CreateNewBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, false, "plataforma", "SO", "VErsao so", TestDataConfig.atribuir, String.Empty, TestDataConfig.descricao, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, false, false);

            JavaScriptExecutorHelper.ExecuteJavaScript("document.getElementById('summary').removeAttribute('required')");

            objNewBug.saveNewBug();

            ValidationResult.AssertElementContainsText(objNewBug.msgErro, MessagesNewBug.MensagemErroObrigatoriedade.Replace("@campo", "summary"));



        }

        [Test, Description("Testa tentar prosseguir sem exibir o campo Descricão e validar se a mensagem de obrigatoriedade foi exibida.")]
        public void TEST_CreateNewBugDescriptionRequired()
        {

            objLogin.NavigateToLoginPage().LogIn();
            objNewBug.OpenNewBugPage().CreateNewBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, false, "plataforma", "SO", "VErsao so", TestDataConfig.atribuir, TestDataConfig.resumo, String.Empty, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, false, false);

            JavaScriptExecutorHelper.ExecuteJavaScript("document.getElementById('description').removeAttribute('required')");

            objNewBug.saveNewBug();

            ValidationResult.AssertElementContainsText(objNewBug.msgErro, MessagesNewBug.MensagemErroObrigatoriedade.Replace("@campo", "description"));
            //A necessary field "description" was empty. Please recheck your inputs.
        }



    }
}
