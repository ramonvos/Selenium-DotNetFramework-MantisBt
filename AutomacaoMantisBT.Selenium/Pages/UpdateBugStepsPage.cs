using AutomacaoMantisBT.Utils.SeleniumBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using AutomacaoMantisBT.Utils.WaitHelpers;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class UpdateBugStepsPage
    {   

        public IWebElement linkVerTarefas => WebdriverHooks.Driver.FindElement(By.LinkText("View Issues"));

        public IWebElement btnUpdateBug => WebdriverHooks.Driver.FindElement(By.XPath("//*[@id='buglist']/tbody/tr[1]/td[2]"));

        public IWebElement btnSave => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Update Information']"));

        public IWebElement ddlCategoria => WebdriverHooks.Driver.FindElement(By.Id("category_id"));

        private By locatorDdlCategoria = By.Id("category_id");
        public IWebElement ddlFrequecia => WebdriverHooks.Driver.FindElement(By.Id("reproducibility"));
        public IWebElement ddlGravidade => WebdriverHooks.Driver.FindElement(By.Id("severity"));
        public IWebElement ddlPrioridade => WebdriverHooks.Driver.FindElement(By.Id("priority"));
        public IWebElement ddlAtribuir => WebdriverHooks.Driver.FindElement(By.Id("handler_id"));

        public IWebElement txtResumo => WebdriverHooks.Driver.FindElement(By.Id("summary"));
        public IWebElement txtDescricao => WebdriverHooks.Driver.FindElement(By.Id("description"));
        public IWebElement txtPassos => WebdriverHooks.Driver.FindElement(By.Id("steps_to_reproduce"));
        public IWebElement txtAdicionais => WebdriverHooks.Driver.FindElement(By.Id("additional_information"));


        public IWebElement btnExpandirPerfil => WebdriverHooks.Driver.FindElement(By.XPath("//a[@id='profile_closed_link']/i"));
        private By locatorbtnExpandirPerfil = By.XPath("//a[@id='profile_closed_link']/i");
        public IWebElement txtPlataforma => WebdriverHooks.Driver.FindElement(By.Id("platform"));
        private By locatortxtPlataforma = By.Id("platform");
        public IWebElement txtSO => WebdriverHooks.Driver.FindElement(By.Id("os"));
        public IWebElement txtVersaoSO => WebdriverHooks.Driver.FindElement(By.Id("os_build"));
        
        public IWebElement ckVisibilidadePrivado => WebdriverHooks.Driver.FindElement(By.Id("private"));
        

        public UpdateBugStepsPage OpenViewTask()
        {
            linkVerTarefas.ClickLink();

            return new UpdateBugStepsPage();
        }

        public UpdateBugStepsPage ClickUpdateBug()
        {
            btnUpdateBug.ClickButton();

            return new UpdateBugStepsPage();
        }


        public UpdateBugStepsPage FillFormUpdateBug(string categoria, string frequencia, string gravidade, string prioridade, bool selecionarPerfil,
           string plataforma, string so, string versaoSo, string atribuirA, string resumo, string descricao, string passos, string informacoesAdicionais, bool privado)
        {

            WaitForElementHelpers.WaitForElementDisplayed(locatorDdlCategoria);
            ddlCategoria.SelectText(categoria);
            ddlFrequecia.SelectText(frequencia);
            ddlGravidade.SelectText(gravidade);
            ddlPrioridade.SelectText(prioridade);
            if (selecionarPerfil)
            {
                WaitForElementHelpers.WaitForElementDisplayed(locatortxtPlataforma);
                txtPlataforma.ClearAndTypeInTextBox(plataforma);
                txtSO.ClearAndTypeInTextBox(so);
                txtVersaoSO.ClearAndTypeInTextBox(versaoSo);
            }

            ddlAtribuir.SelectText(atribuirA);

            txtResumo.ClearAndTypeInTextBox(resumo);
            txtDescricao.ClearAndTypeInTextBox(descricao);
            txtPassos.ClearAndTypeInTextBox(passos);

            txtAdicionais.ClearAndTypeInTextBox(informacoesAdicionais);

            if (privado)
            {
                ckVisibilidadePrivado.RadioButtonSelect();
            }
        
            //txtEnviarArquivos.SendKeys(@"C:\Users\ramon\source\repos\AutomacaoMantisBT-Ramon\AutomacaoMantisBT.Testes\bin\Debug\TestResult\2018-10-05\ReportTest - sexta-feira, 5 de outubro de 2018.html");



            return new UpdateBugStepsPage();
        }



        public UpdateBugStepsPage ClickSaveUpdate()
        {
            btnSave.ClickButton();

            return new UpdateBugStepsPage();
        }
    }
}
