using AutomacaoMantisBT.Utils.SeleniumBase;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class DeleteBugSPage
    {
        public IWebElement linkVerTarefas => WebdriverHooks.Driver.FindElement(By.LinkText("Ver Tarefas"));

        public IWebElement ckSelecionarBug => WebdriverHooks.Driver.FindElement(By.XPath("//table[@id='buglist']/tbody/tr/td/div/label/span"));


        public IWebElement linkDetalharBug => WebdriverHooks.Driver.FindElement(By.XPath("//table[@id='buglist']/tbody/tr/td[4]/a"));        

        public IWebElement ddlSelecionarAcaoRemover => WebdriverHooks.Driver.FindElement(By.Name("action"));

        public IWebElement btnOk => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='OK']"));

        public IWebElement btnConfirmar => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Apagar Tarefas']"));

        public IWebElement btnApagar => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Apagar']"));

        public IWebElement msgSucesso => WebdriverHooks.Driver.FindElement(By.XPath("//*[@id='bug_action']/div/div[1]/h4"));
        public DeleteBugSPage OpenViewTask()
        {
            linkVerTarefas.ClickLink();
            return new DeleteBugSPage();
        }

        public DeleteBugSPage DeleteBugFromList()
        {
            string action = "Apagar";
            
            

            ckSelecionarBug.CheckboxChecked();

            ddlSelecionarAcaoRemover.SelectText(action);

            btnOk.ClickButton();

            btnConfirmar.ClickButton();
            return new DeleteBugSPage();
        }


        public DeleteBugSPage DeleteBugFromDetails()
        {

            linkDetalharBug.ClickLink();

            btnApagar.ClickButton();
            btnConfirmar.ClickButton();

            return new DeleteBugSPage();
        }

    }
}
