using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Testes.Resources;
using AutomacaoMantisBT.Testes.TestData;
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
    [TestFixture, Order(5)]
    public class UpdateBugsStepsTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] CreateNewBugPage objNewBug;
        [PageObject] UpdateBugStepsPage objUpdBug;

        [Test, Description("")]
        public void TEST_UpdateBugStepsSuccess()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objUpdBug.OpenViewTask().ClickUpdateBug();

            objUpdBug.FillFormUpdateBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, true, "plataforma", "SO", "VErsao so", TestDataConfig.atribuir, TestDataConfig.resumo, TestDataConfig.descricao, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, false);

            objUpdBug.ClickSaveUpdate();

            ValidationResult.AssertElementContainsText(objNewBug.msgSucesso, MessagesUpdateBug.MensagemSucesso);

        }

        [Test, Description("")]
        public void TEST_UpdateBugStepsSummaryRequired()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objUpdBug.OpenViewTask().ClickUpdateBug();

            objUpdBug.FillFormUpdateBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, true, "plataforma", "SO", "VErsao so", TestDataConfig.atribuir, String.Empty, TestDataConfig.descricao, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, false);

            objUpdBug.ClickSaveUpdate();

            ValidationResult.AssertElementContainsText(objNewBug.msgErro, MessagesUpdateBug.MensagemErroObrigatoriedade.Replace("@campo","Resumo"));


        }

        [Test, Description("")]
        public void TEST_UpdateBugStepsDescriptionRequired()
        {
            objLogin.NavigateToLoginPage().LogIn();

            objUpdBug.OpenViewTask().ClickUpdateBug();

            objUpdBug.FillFormUpdateBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, true, "plataforma", "SO", "VErsao so", TestDataConfig.atribuir, TestDataConfig.resumo, String.Empty, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, false);

            objUpdBug.ClickSaveUpdate();

            ValidationResult.AssertElementContainsText(objNewBug.msgSucesso, MessagesUpdateBug.MensagemErroObrigatoriedade.Replace("@campo", "Resumo"));

        }

        [Test, Description("")]
        public void TEST_UpdateBugStepsReproductionRequired()
        {

        }

       

    }
}
