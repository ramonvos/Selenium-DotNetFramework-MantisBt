using AutomacaoMantisBT.Utils.SeleniumBase;
using AutomacaoMantisBT.Utils.SeleniumHelpers;
using AutomacaoMantisBT.Utils.WaitHelpers;
using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class CreateNewBugPage
    {   
        public const String url = "";
        public IWebElement linkCriarTarefa => WebdriverHooks.Driver.FindElement(By.LinkText("Report Issue"));


        public IWebElement ddlCategoria => WebdriverHooks.Driver.FindElement(By.Id("category_id"));

        private By locatorDdlCategoria = By.Id("category_id");
        public IWebElement ddlFrequecia => WebdriverHooks.Driver.FindElement(By.Id("reproducibility"));
        public IWebElement ddlGravidade => WebdriverHooks.Driver.FindElement(By.Id("severity"));
        public IWebElement ddlPrioridade => WebdriverHooks.Driver.FindElement(By.Id("priority"));
        public IWebElement ddlAtribuir => WebdriverHooks.Driver.FindElement(By.Id("handler_id"));


        public IWebElement txtResumo => WebdriverHooks.Driver.FindElement(By.Id("summary"));
        public IWebElement txtDescricao => WebdriverHooks.Driver.FindElement(By.Id("description"));
        public IWebElement txtPassos => WebdriverHooks.Driver.FindElement(By.Id("steps_to_reproduce"));
        public IWebElement txtAdicionais => WebdriverHooks.Driver.FindElement(By.Id("additional_info"));

        
        

        public IWebElement txtMarcadores => WebdriverHooks.Driver.FindElement(By.Id("tag_string"));

        public IWebElement btnExpandirPerfil => WebdriverHooks.Driver.FindElement(By.XPath("//a[@id='profile_closed_link']/i"));
        private By locatorbtnExpandirPerfil = By.XPath("//a[@id='profile_closed_link']/i");

        public IWebElement txtPlataforma => WebdriverHooks.Driver.FindElement(By.Id("platform"));
        private By locatortxtPlataforma =By.Id("platform");
        public IWebElement txtSO => WebdriverHooks.Driver.FindElement(By.Id("os"));
        public IWebElement txtVersaoSO => WebdriverHooks.Driver.FindElement(By.Id("os_build"));

        public IWebElement txtEnviarArquivos => WebdriverHooks.Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Tamanho máximo: 5,000 kB'])[1]/following::div[1]"));

        public IWebElement rbVisibilidadePublico => WebdriverHooks.Driver.FindElement(By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[13]/td/label/span"));
        public IWebElement rbVisibilidadePrivado => WebdriverHooks.Driver.FindElement(By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[13]/td/label[2]/span"));
        public IWebElement ckContinuarRelatando => WebdriverHooks.Driver.FindElement(By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[14]/td/label/span"));


        public IWebElement btnSalvar => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Submit Issue']"));


        public IWebElement msgSucesso => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p"));
        public By msgSucessoLocator = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");

        public IWebElement msgErro => WebdriverHooks.Driver.FindElement(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]"));


        public CreateNewBugPage OpenNewBugPage()
        {
            linkCriarTarefa.ClickButton();

            return new CreateNewBugPage();
        }
        public CreateNewBugPage CreateNewBug(string categoria, string frequencia, string gravidade, string prioridade,bool selecionarPerfil, 
            string plataforma, string so,string versaoSo,string atribuirA, string resumo, string descricao, string passos, string informacoesAdicionais, bool privado, bool continuarRelatando)
        {

            WaitForElementHelpers.WaitForElementDisplayed(locatorDdlCategoria);
            ddlCategoria.SelectText(categoria);
            ddlFrequecia.SelectText(frequencia);
            ddlGravidade.SelectText(gravidade);
            ddlPrioridade.SelectText(prioridade);
            if (selecionarPerfil)
            {
                if (SelecionarPerfilOculto()) {
                    btnExpandirPerfil.ClickButton();
                }
                
              
                WaitForElementHelpers.WaitForElementDisplayed(locatortxtPlataforma);
                txtPlataforma.TypeInTextBox(plataforma);
                txtSO.TypeInTextBox(so);
                txtVersaoSO.TypeInTextBox(versaoSo);
            }

            ddlAtribuir.SelectText(atribuirA);

            txtResumo.TypeInTextBox(resumo);
            txtDescricao.TypeInTextBox(descricao);
            txtPassos.TypeInTextBox(passos);

            txtAdicionais.TypeInTextBox(informacoesAdicionais);

            if (privado)
            {
                rbVisibilidadePrivado.RadioButtonSelect();
            }
            if (continuarRelatando)
            {
                ckContinuarRelatando.CheckboxChecked();
            }
            //txtEnviarArquivos.SendKeys(@"C:\Users\ramon\source\repos\AutomacaoMantisBT-Ramon\AutomacaoMantisBT.Testes\bin\Debug\TestResult\2018-10-05\ReportTest - sexta-feira, 5 de outubro de 2018.html");
            


            return new CreateNewBugPage();
        }

        public CreateNewBugPage saveNewBug()
        {

            btnSalvar.ClickButton();

            return new CreateNewBugPage();
        }

        private bool SelecionarPerfilOculto()
        {
            try
            {
                return btnExpandirPerfil.Displayed;
            }
            catch 
            {

                return false;
            }
        }

    }
}
