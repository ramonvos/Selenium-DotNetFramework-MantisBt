using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutomacaoMantisBT.Utilitarios.SeleniumBase;
using AutomacaoMantisBT.Utilitarios.SeleniumHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoMantisBT.Utilitarios.ProjectUtilities;

namespace AutomacaoMantisBT.Selenium.Pages
{
    public class LoginPage
    {
       

        public IWebElement txtLogin => WebdriverHooks.Driver.FindElement(By.Id("username"));

        public IWebElement txtPass => WebdriverHooks.Driver.FindElement(By.Id("password"));

        public IWebElement btnEntrar => WebdriverHooks.Driver.FindElement(By.XPath("//input[@value='Entrar']"));

        //public IWebElement msgErroLogin => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='main-container']/div/div/div/div/div[4]/p"));
        public IWebElement msgErroLogin => WebdriverHooks.Driver.FindElement(By.XPath("//div[@id='main-container']/div/div/div/div/div[4]"));


        public LoginPage NavegarPaginaLogin()
        {
            WebdriverHooks.Driver.Manage().Cookies.DeleteAllCookies();
            NavigationHelper.NavigateToPage(ConfigurationManager.AppSettings["URL_BASE"]+ "login_page.php");

            return new LoginPage();
        }

        public LoginPage LogIn()
        {
            string user = ConfigurationManager.AppSettings["USERNAME"];
            string pass = ConfigurationManager.AppSettings["PASSWORD"];
            txtLogin.TypeInTextBox(user);
            btnEntrar.ClickButton();

            txtPass.TypeInTextBox(pass);
            btnEntrar.ClickButton();

            return new LoginPage();


        }

        public LoginPage LogIn(string user, string pass )
        {
            
            txtLogin.TypeInTextBox(user);
            btnEntrar.ClickButton();
            if (user.HasValue())
            {
                txtPass.TypeInTextBox(pass);
                btnEntrar.ClickButton();
            }

        


            return new LoginPage();


        }

      
    }
}
