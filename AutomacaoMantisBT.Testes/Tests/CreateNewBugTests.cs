using NUnit.Framework;
using Selenium.MapaCarreira.Testes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utilitarios.AssertsHelpers;
using AutomacaoMantisBT.Utilitarios.DependencyInjection;
using AutomacaoMantisBT.Selenium.Pages;
using AutomacaoMantisBT.Testes.TestData;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;

namespace Selenium.MapaCarreira.Testes.Tests
{
    [TestFixture,Order(2)]
    public class CreateNewBugTests : TestBase
    {
        [PageObject] LoginPage objLogin;
        [PageObject] CreateNewBugPage objNewBug;

        [Test, Description("")]
        public void TEST_CreateNewBugAllFieldsSuccess()
        {
            objLogin.NavegarPaginaLogin().LogIn();
            objNewBug.CreateNewBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, true,"plataforma","SO","VErsao so",TestDataConfig.atribuir, TestDataConfig.resumo, TestDataConfig.descricao, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, true, true);

            ValidationResult.AssertTextInElement(objNewBug.msgSucesso, "Operação realizada com sucesso.");

        }

        [Test, Description("")]
        public void TEST_CreateNewBugRequiredFieldsSuccess()
        {
            objLogin.NavegarPaginaLogin().LogIn();
            objNewBug.CreateNewBug(String.Empty, String.Empty, String.Empty, String.Empty, false, String.Empty, String.Empty, String.Empty, String.Empty, TestDataConfig.resumo, TestDataConfig.descricao, String.Empty, String.Empty, false, false);

            ValidationResult.AssertTextInElement(objNewBug.msgSucesso, "Operação realizada com sucesso.");

        }

        [Test, Description("")]
        public void TEST_CreateNewBugSummaryRequired()
        {


            objLogin.NavegarPaginaLogin().LogIn();
            objNewBug.CreateNewBug(TestDataConfig.categoria, TestDataConfig.frequencia, TestDataConfig.gravidade, TestDataConfig.prioridade, false, "plataforma", "SO", "VErsao so", TestDataConfig.atribuir, TestDataConfig.resumo, TestDataConfig.descricao, TestDataConfig.passosReproduzir, TestDataConfig.informacoesAdicionais, false, false);

            Console.WriteLine("");

        }

        [Test, Description("")]
        public void TEST_CreateNewBugDescriptionRequired()
        {

        }

        [Test, Description("")]
        public void TEST_CreateNewBugStepsForReproductionRequired()
        {

        }

        [Test, Description("")]
        public void TEST_CreateNewBugAttachmentRequired()
        {

        }


    }
}
